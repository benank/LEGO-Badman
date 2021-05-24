using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public int ItemIndex = -1; // ID
    [SerializeField] float TimeToSpawn = 1f;
    [SerializeField] float TimeToHover = 5f;
    [SerializeField] float TimeToFlySmooth = 0.5f;

    private Vector3 CurrentVelocity = Vector3.zero;
    [SerializeField] private float RotateSpeed = 10f;

    [SerializeField] float BobbingIntensity = 0.005f;
    [SerializeField] float BobbingFrequency = 3f;

    [SerializeField] float CollectionRadius = 5f;
    [SerializeField] float DetectionRadius = 15f;


    [SerializeField] public GameObject Target = null;

    void Start()
    {
        RandomizeTimes();
        StartCoroutine(StartBehaviour());
        StartCoroutine(DetectProximity());
    }

    private void RandomizeTimes()
    {
        TimeToSpawn = Random.Range(0.5f, 1.5f);
        TimeToHover = Random.Range(3f, 5f);
        TimeToFlySmooth = Random.Range(0.3f, 0.5f);
    }

    IEnumerator DetectProximity()
    {
        /* Continually Check if Item is close enough to collector to be picked up automatically */
        while (true)
        {
            if (Target == null)
            {
                Debug.Log("No Target Attached, No check proximity.");
                break;
            }

            if (GetDistanceToTarget() <= DetectionRadius)
            {
                this.StopAllCoroutines();
                StartCoroutine(StartFlyToTarget());
                break;
            }
            yield return null;
        }
    }

    IEnumerator StartBehaviour()
    {
        // Do Nothing for TimeToSpawn seconds
        yield return new WaitForSeconds(TimeToSpawn);

        StartCoroutine(StartHover());
    }
    IEnumerator StartHover()
    {
        /* Let Item float in place for a few seconds*/

        // Remove RigidBody to avoid physics
        float timePassed = 0f;
        Destroy(this.gameObject.GetComponent<Rigidbody>());

        while (timePassed < TimeToHover)
        {
            timePassed += Time.deltaTime;

            // Bobbing Animation
            var newPosition = Vector3.up * Mathf.Cos(timePassed * BobbingFrequency) * BobbingIntensity;
            this.gameObject.transform.position += newPosition;

            // Reset Rotation
            var newRotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, Quaternion.identity, timePassed * RotateSpeed);
            this.gameObject.transform.rotation = newRotation;

            yield return null;
        }

        StartCoroutine(StartFlyToTarget());
    }
    IEnumerator StartFlyToTarget()
    {
        /* Move item towards collector */

        float timePassed = 0f;
        this.StopCoroutine(DetectProximity());

        while (true)
        {
            if (Target == null)
            {
                Debug.Log("No Target Attached, will Despawn.");
                Destroy(this.gameObject);
                break;
            }
            // Set Position
            var newPosition = Vector3.SmoothDamp(
                this.gameObject.transform.position,
                Target.transform.position,
                ref CurrentVelocity,
                TimeToFlySmooth
                );
            this.gameObject.transform.position = newPosition;
            // Set Rotation
            var direction = (Target.transform.position - this.gameObject.transform.position).normalized;
            var lookTo = Quaternion.LookRotation(direction);
            var newRotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, lookTo, timePassed * RotateSpeed);
            timePassed += Time.deltaTime;

            this.gameObject.transform.rotation = newRotation;

            if (GetDistanceToTarget() <= CollectionRadius) {
                GetCollected();
                break;
            
            }
            yield return null;
        }
    }

    private void GetCollected()
    {
        if(ItemIndex == -1)
        {
            Debug.Log("Invalid Item Index, Not marked on Instantiate.");
            return;
        }
        var targetInventory = Target.GetComponentInParent<ItemController>();
        targetInventory.CollectItem(ItemIndex);
        Destroy(this.gameObject);
    }

    private float GetDistanceToTarget()
    {
        var currentPosition = this.gameObject.transform.position;
        var targetPosition = Target.transform.position;

        return Vector3.Distance(currentPosition, targetPosition);

    }
}

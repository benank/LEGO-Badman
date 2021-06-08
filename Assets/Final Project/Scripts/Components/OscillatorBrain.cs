using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorBrain : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float transitionRate;
    [SerializeField] private float transitionDelay;
    private Vector3 currentTravelDestination;
    private bool canTransition = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        transform.position = startPosition;
        currentTravelDestination = endPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTransition)
        {
            return;
        }

        if (transform.position == startPosition)
        {
            StartCoroutine("DelayPlatformTransition");
            currentTravelDestination = endPosition;
        }
        else if (transform.position == endPosition)
        {
            StartCoroutine("DelayPlatformTransition");
            currentTravelDestination = startPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTravelDestination, transitionRate * Time.deltaTime);
    }

    IEnumerator DelayPlatformTransition()
    {
        canTransition = false;
        yield return new WaitForSeconds(transitionDelay);
        canTransition = true;
    }
}

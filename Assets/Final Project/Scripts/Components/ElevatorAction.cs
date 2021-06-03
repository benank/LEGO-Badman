using Interactable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAction : Interactable.TriggerableAction
{
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    [SerializeField] private bool IsReturning;
    [SerializeField] private bool IsMoving = false;
    [SerializeField] private float MovementSpeed = 10f;

    [SerializeField] private List<string> triggerTags = new List<string>();
    [SerializeField] private bool isActive = true;

    [SerializeField]
    private GameObject Player;


    void Awake()
    {
        this.onActivate = delegate (Interactable.TriggerData td)
        {
            Triggered(td);
        };
        if (IsReturning)
        {
            transform.position = PointB.position;

        }
        else
        {
            transform.position = PointA.position;

        }

        var colliderSubscriber = gameObject.GetComponentInChildren<IColliderSubscriber<Collider, bool>>();
        if (colliderSubscriber != null)
        {
            colliderSubscriber.callbackEvent += OnTriggerEnterExit;
        }
    }

    void OnTriggerEnterExit(Collider other, bool entered)
    {
        if (triggerTags.Contains(other.gameObject.tag) && isActive && entered)
        {
            GameObjectEnteredTrigger(other.gameObject);
        }
    }
    void GameObjectEnteredTrigger(GameObject go)
    {
        if (PointA == null || PointB == null) { return; }
        Move(go);
    }

    IEnumerator MoveToA(GameObject go)
    {
        yield return new WaitForSeconds(0.25f);
        IsMoving = true;

        while (!transform.position.Equals(PointA.position))
        {
            float step = Time.deltaTime * MovementSpeed;
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, step);
            yield return null;
        }
        IsReturning = false;
        IsMoving = false;
    }
    IEnumerator MoveToB(GameObject go)
    {
        yield return new WaitForSeconds(0.25f);
        IsMoving = true;

        while (!transform.position.Equals(PointB.position))
        {
            float step = Time.deltaTime * MovementSpeed;
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, step);
            yield return null;
        }
        IsReturning = true;
        IsMoving = false;

    }
    void Move(GameObject go)
    {
        if (!IsMoving)
        {
            if (IsReturning)
            {
                StartCoroutine(MoveToA(go));
            }
            else
            {
                StartCoroutine(MoveToB(go));
            }
        }
    }
    public void Triggered(TriggerData td)
    {
        if (td.pressed)
        {
            isActive = !isActive;
        }
    }
}

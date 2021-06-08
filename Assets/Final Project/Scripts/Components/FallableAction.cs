using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallableAction : Interactable.TriggerableAction
{
    [SerializeField] private float fallSpeed;
    [SerializeField] private float fallDistance;
    private Vector3 initialPoint;
    private Vector3 fallPoint;

    void Start()
    {
        this.onActivate = delegate (Interactable.TriggerData td)
        {
            Triggered(td);
        };

        initialPoint = transform.position;
        fallPoint = transform.position - new Vector3(0.0f, fallDistance, 0.0f);
    }

    void Triggered(Interactable.TriggerData td)
    {
        if (td.pressed)
        {
            td.triggerGameObject.transform.position = Vector3.MoveTowards(td.triggerGameObject.transform.position, fallPoint, fallSpeed * Time.deltaTime);
        }
        else
        {
            td.triggerGameObject.transform.position = Vector3.MoveTowards(td.triggerGameObject.transform.position, initialPoint, fallSpeed * Time.deltaTime);
        }
    }

}

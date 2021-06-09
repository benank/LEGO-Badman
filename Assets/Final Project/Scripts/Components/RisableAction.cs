using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisableAction : Interactable.TriggerableAction
{
    [SerializeField] private float riseSpeed;
    [SerializeField] private float riseDistance;
    private Vector3 initialPoint;
    private Vector3 risePoint;

    void Start()
    {
        this.onActivate = delegate (Interactable.TriggerData td)
        {
            Triggered(td);
        };

        initialPoint = transform.position;
        risePoint = transform.position + new Vector3(0.0f, riseDistance, 0.0f);
    }

    void Triggered(Interactable.TriggerData td)
    {
        if (td.pressed)
        {
            td.triggerGameObject.transform.position = Vector3.MoveTowards(td.triggerGameObject.transform.position, risePoint, riseSpeed * Time.deltaTime);
        }
        else
        {
            td.triggerGameObject.transform.position = Vector3.MoveTowards(td.triggerGameObject.transform.position, initialPoint, riseSpeed * Time.deltaTime);
        }
    }

}

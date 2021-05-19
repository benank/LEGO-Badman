using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggerAction : Interactable.TriggerableAction
{
    private Vector3 targetOffset;
    private Vector3 originalPosition;
    
    [SerializeField] private float speed = 1;
    
    void Awake()
    {
        this.onActivate = delegate (Interactable.TriggerData td)
        {
            Triggered(td);
        };
        
        originalPosition = transform.position;
    }
    
    void Update()
    {
        if (targetOffset != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, originalPosition + targetOffset, Time.deltaTime * speed);
        }
    }
    
    void Triggered(Interactable.TriggerData td)
    {
        if (td.pressed)
        {
            targetOffset = Vector3.up * 5;
        }
        else
        {
            targetOffset = Vector3.zero;
        }
    }
}

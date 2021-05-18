using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggerAction : Interactable.TriggerableAction
{
    void Awake()
    {
        this.onActivate = delegate (Interactable.TriggerData td)
        {
            Triggered(td);
        };
    }
    
    void Triggered(Interactable.TriggerData td)
    {
        this.transform.position += Vector3.up;
    }
}

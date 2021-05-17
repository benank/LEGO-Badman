using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggerAction : Interactable.TriggerableAction
{
    void Awake()
    {
        this.onActivate = delegate (Interactable.TriggerType tt)
        {
            Triggered(tt);
        };
    }
    
    void Triggered(Interactable.TriggerType tt)
    {
        this.transform.position += Vector3.up;
    }
}

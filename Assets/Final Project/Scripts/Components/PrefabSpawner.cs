using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : Interactable.TriggerableAction
{
    [SerializeField] private GameObject prefabToSpawn;
    
    void Start()
    {
        this.onActivate = delegate (Interactable.TriggerData td)
        {
            Triggered(td);
        };
    }

    void Triggered(Interactable.TriggerData td)
    {
        if (td.pressed)
        {
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBehaviourTest : MonoBehaviour
{
    void Awake()
    {
        var CollectionPoint = GameObject.FindGameObjectWithTag("Collector");
        this.gameObject.GetComponent<ItemController>().Target = CollectionPoint;
        var CollectionParentObject = CollectionPoint.transform.parent.gameObject;
        if(CollectionParentObject.GetComponent<ItemController>() == null){
            CollectionParentObject.AddComponent<ItemController>();
        }
    }

}

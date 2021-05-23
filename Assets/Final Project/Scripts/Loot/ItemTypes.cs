using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypes : MonoBehaviour
{
    public int Count;
    public List<GameObject> ObjectTypes = new List<GameObject>();

    private void Awake()
    {
        Count = ObjectTypes.Count;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypes : MonoBehaviour
{
    // Allows other scripts to access as a singleton script.
    public static ItemTypes instance = null;

    public int Count;
    public List<GameObject> ObjectTypes = new List<GameObject>();

    //Awake is always called before any Start functions
    private void Awake()
    {
        // Set instance to this once only.
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Count = ObjectTypes.Count;
    }
}

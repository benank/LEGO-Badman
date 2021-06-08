using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintSpecs : MonoBehaviour
{
    // Allows other scripts to access as a singleton script.
    public static BlueprintSpecs instance = null;
    [SerializeField]
    public Dictionary<string, List<int>> Blueprints = new Dictionary<string, List<int>>()
    {
      {"Lever",new List<int>{0, 0, 0, 4, 4}}
    };

    //Awake is always called before any Start functions
    private void Awake()
    {
        // Set instance to this once only.
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }
}

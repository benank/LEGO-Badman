using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Allows other scripts to access Game Manager as a singleton script.
    public static GameController instance = null;

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

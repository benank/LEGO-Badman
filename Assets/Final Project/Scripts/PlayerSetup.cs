using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public static PlayerSetup instance = null;

    public GameObject ItemCollector;
    public GameObject Player;

    void Awake()
    {
        // Set instance to this once only.
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        ItemCollector = GameObject.FindGameObjectWithTag("Collector");

        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player.GetComponent<ItemController>() == null)
        {
            Player.AddComponent<ItemController>();
        }
        if (Player.GetComponent<BlueprintController>() == null)
        {
            Player.AddComponent<BlueprintController>();
        }

    }

}

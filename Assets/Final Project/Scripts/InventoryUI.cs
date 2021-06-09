using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

   

    public GameObject Player;
    
    void Start() 
    {
        if(Player.GetComponent<ItemController>() != null)
        {
            var inventory = Player.GetComponent<ItemController>();
        }
    }
    // InventoryUI inventory;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     inventory = Inventory.instance;
    // }

    // Update is called once per frame
    void UpdateUI()
    {   
        Debug.Log("Updating UI");
    }
}

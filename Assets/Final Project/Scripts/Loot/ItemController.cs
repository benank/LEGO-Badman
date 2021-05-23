using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.GetComponent<EventController>().EventMethod = CreateRandomItemTable;
    }
    /*
     * Creates a List of Items to attach to object.
     */
    public static void CreateRandomItemTable()
    {
        Debug.Log("Creating Random Set of Items!");

        string log = "Items Chosen : ";
        int numItems = Random.Range(0, 10);
        List<int> itemIndices = new List<int>(numItems);
        int numItemTypes = GameController.instance.GetComponent<ItemTypes>().Count;

        for (int i = 0; i < numItems; ++i)
        {
            itemIndices.Add(Random.Range(0, numItemTypes - 1));
           log += itemIndices[i].ToString() + ", ";

        }
        Debug.Log(log);
    }

}
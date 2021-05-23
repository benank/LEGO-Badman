using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] List<int> ItemsHeld;

    // Update Text
    [SerializeField] TMPro.TextMeshProUGUI inventoryNumber;

    private void Awake()
    {
        this.gameObject.GetComponent<EventController>().Event1 = CreateRandomItemTable;
        this.gameObject.GetComponent<EventController>().Event2 = DropItems;
    }
    private void Update()
    {
        this.gameObject.GetComponent<EventController>().Event2 = DropItems;
        inventoryNumber.text = ItemsHeld.Count.ToString();

    }
    /*
     * Creates a List of Items to attach to object.
     */
    public void CreateRandomItemTable()
    {
        Debug.Log("Creating Random Set of Items!");

        string log = "Items Chosen : ";
        int numItems = Random.Range(1, 10);
        List<int> itemIndices = new List<int>(numItems);
        int numItemTypes = ItemTypes.instance.Count;

        for (int i = 0; i < numItems; ++i)
        {
            itemIndices.Add(Random.Range(0, numItemTypes - 1));
            log += itemIndices[i].ToString() + ", ";

        }
        ItemsHeld = itemIndices;
        Debug.Log(log);
    }
    public void DropItems()
    {
        Debug.Log("Dropping Items!");

        var prefabList = ItemTypes.instance.ObjectTypes;
        foreach (var itemIndex in ItemsHeld)
        {
            GameObject instance = Instantiate(prefabList[itemIndex]) as GameObject;
            instance.transform.SetPositionAndRotation(this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        ItemsHeld.Clear();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private List<int> ItemsHeld;
    [SerializeField] public GameObject Target = null;

    // Update Test Area Text
    [SerializeField] TMPro.TextMeshProUGUI inventoryNumber;

    private void Awake()
    {
        if (this.GetComponent<EventController>() != null)
        {
            this.gameObject.GetComponent<EventController>().Event1 = CreateRandomItemTable;
            this.gameObject.GetComponent<EventController>().Event2 = DropItems;
        }
    }
    private void Update()
    {
        inventoryNumber.text = ItemsHeld.Count.ToString(); 
    }
    /*
     * Creates a List of Items to attach to object.
     */
    public void CreateRandomItemTable()
    {
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
    /*
     * Instantiate all items with attached behaviour script 
     */
    public void DropItems()
    {
        var prefabList = ItemTypes.instance.ObjectTypes;
        foreach (var itemIndex in ItemsHeld)
        {
            GameObject instance = Instantiate(prefabList[itemIndex]) as GameObject;
            var itemBehaviour = instance.AddComponent<ItemBehaviour>();
            itemBehaviour.ItemIndex = itemIndex;
            itemBehaviour.Target = Target;

            instance.transform.SetPositionAndRotation(this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        ItemsHeld.Clear();
    }

    public void CollectItem(int itemIndex)
    {
        ItemsHeld.Add(itemIndex);
    }

}
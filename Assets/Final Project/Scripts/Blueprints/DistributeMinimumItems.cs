using System.Collections.Generic;
using UnityEngine;

public class DistributeMinimumItems : MonoBehaviour
{
    [SerializeField]
    private List<string> MinimumRequiredBlueprints = new List<string>();
    [SerializeField]
    private Dictionary<int, int> itemTypeCounts = new Dictionary<int, int>();
    [SerializeField]
    private List<ItemController> allLootableObjects = new List<ItemController>();
    [SerializeField]
    private string LootableTag = "Lootable";


    void Start()
    {
        // Find items needed.
        foreach (var blueprintName in MinimumRequiredBlueprints)
        {
            bool isValid = BlueprintSpecs.instance.Blueprints.TryGetValue(blueprintName, out List<int> recipe);
            if (isValid)
                CalculateItemCounts(recipe);
            else
                Debug.LogWarning("Blueprint <" + blueprintName + "> not found in blueprint specs list.");
        }

        // Minimum needed items calculated, time to distribute.
        Distrubute();
    }

    private void Distrubute()
    {
        // Add lootable objects to list
        var itemControllers = FindObjectsOfType<ItemController>();
        foreach (var itemController in itemControllers)
        {
            if (itemController.gameObject.CompareTag(LootableTag) || (itemController.transform.parent != null && itemController.transform.parent.CompareTag(LootableTag))) {
                if(!itemController.isInventoryFixed)
                    allLootableObjects.Add(itemController);
            }
        }
        if(allLootableObjects.Count == 0)
        {
            // No objects available to distrbute to.
            return;
        }
        // Distribute items to list
        foreach (var item in itemTypeCounts)
        {
            // For every item type (item.Key), distribute n items (=item.Value) randomly.
            for (int i = 0; i < item.Value; ++i)
            {
                int index = Random.Range(0, allLootableObjects.Count);
                allLootableObjects[index].CollectItem(item.Key);
            }
        }
    }

    private void CalculateItemCounts(List<int> recipe)
    {
        // Add each type of item to total item counts
        foreach (var item in recipe)
        {
            if (itemTypeCounts.ContainsKey(item))
            {
                ++itemTypeCounts[item];
            }
            else
            {
                itemTypeCounts.Add(item, 1);
            }
        }
    }
}

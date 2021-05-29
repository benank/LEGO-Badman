using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    [SerializeField] private string BlueprintName;
    [SerializeField] private List<int> BlueprintRecipe;
    [SerializeField] private GameObject BlueprintPrefab;

    /* Prefab type and location is currently set by on click of BuildZone. 
     * TODO: Later let prefab type be set by build menu; and location by build zone.
     */
    public void SetCurrentBlueprint(string name, GameObject prefab)
    {
        BlueprintName = name;
        BlueprintRecipe = BlueprintSpecs.instance.Blueprints[name];
        BlueprintPrefab = prefab;
    }

    public bool BuildBlueprint()
    {
        if(BlueprintName == "")
        {
            Debug.Log("No Blueprint Name given!");
            return false;
        }

        var PlayerItemManager = this.gameObject.GetComponent<ItemController>();

        if (CheckIfCanBuild(PlayerItemManager.GetInventory(), BlueprintRecipe))
        {
            // Add items to prefab inventory
            BlueprintPrefab.AddComponent<ItemController>();
            BlueprintPrefab.GetComponent<ItemController>().SetInventory(BlueprintRecipe);

            // Remove consumed items from player inventory
            this.gameObject.GetComponent<ItemController>().SetInventory(RemoveItems(PlayerItemManager.GetInventory(), BlueprintRecipe));

            return true;
        }
        
        Debug.Log("Not enough items!");
        return false;
    }
    private List<int> RemoveItems(List<int> RemoveFrom, List<int> ItemsToRemove)
    {
        var items = RemoveFrom;
        foreach (var item in ItemsToRemove)
        {
            items.Remove(item);
        }
        return items;
    }
    public string ItemsToString(List<int> blueprintType)
    {
        string text = "";
        for (int i = 0; i < ItemTypes.instance.Count; ++i)
        {
            var subCount = GetCountOfItemType(i, blueprintType);
            if (subCount > 0)
            {
                text += ItemTypes.instance.ObjectTypes[i].name;
                text += ": ";
                text += subCount;
                text += "  ";
            }
        }

        return text;
    }
    public int GetCountOfItemType(int itemIndex, List<int> blueprintType)
    {
        int count = 0;
        foreach (var item in blueprintType)
        {
            if (item == itemIndex)
            {
                ++count;
            }
        }
        return count;
    }
    public bool CheckIfCanBuild(List<int> itemsHeld, List<int> blueprint)
    {
        for (int i = 0; i < ItemTypes.instance.Count; ++i)
        {
            var subCountHeld = GetCountOfItemType(i, itemsHeld);
            var subCountBlueprint = GetCountOfItemType(i, blueprint);
            if (subCountHeld < subCountBlueprint)
            {
                // Does not have enough items of this type
                return false;
            }
        }
        return true;
    }
}

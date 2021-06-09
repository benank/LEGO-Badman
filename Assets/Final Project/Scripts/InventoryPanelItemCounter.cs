using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelItemCounter : MonoBehaviour
{
    [SerializeField] private ItemController PlayerInventory;
    [SerializeField] private TMPro.TextMeshProUGUI Text;
    [SerializeField] private int itemTypeIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        Text = this.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        PlayerInventory = PlayerSetup.instance.Player.GetComponent<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = PlayerInventory.GetCountOfItemType(itemTypeIndex).ToString();
    }
}

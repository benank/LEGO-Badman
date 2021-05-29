using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryText : MonoBehaviour
{
    [SerializeField] private ItemController PlayerInventory;
    [SerializeField] private TMPro.TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory = PlayerSetup.instance.Player.GetComponent<ItemController>();
        Text = this.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = PlayerInventory.ItemsToString();
    }
}

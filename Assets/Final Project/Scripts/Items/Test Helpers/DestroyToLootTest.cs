using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyToLootTest : MonoBehaviour
{
    [SerializeField] private float HealthPoints = 100f;
    [SerializeField] private ItemController ItemsManager;
    private void Awake()
    {
        if (this.GetComponent<EventController>() != null)
        {
            this.gameObject.GetComponent<EventController>().Event1 = DamageObject;
        }
        if (this.GetComponent<ItemController>() == null)
        {
            ItemsManager = this.gameObject.AddComponent<ItemController>();
        }
    }
    public void Start()
    {
        ItemsManager.CreateRandomItemTable();
    }
    public void DamageObject()
    {
        HealthPoints -= 25f;
        if (HealthPoints <= 0)
        {
            ItemsManager.DropItems();
            Destroy(gameObject);
        }
    }
}

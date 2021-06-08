using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Interactable;

public class DestroyObjectAction : TriggeredAction
{
    [Tooltip("Name of the input button/key that breaks the object")]
    [SerializeField] private string triggerInput = "Fire1";
    private bool triggered = false;

    [SerializeField] private float HealthPoints = 100f;
    [SerializeField] private ItemController ItemsManager;
    [SerializeField] private float destroyRadius = 5f;
    
    private ShakeObject ObjectShaker;
    [SerializeField] private float ShakeDuration = 0.1f;


    private void Awake()
    {
        if (this.GetComponent<ItemController>() == null)
        {
            ItemsManager = this.gameObject.AddComponent<ItemController>();
        }
        else
        {
            ItemsManager = this.gameObject.GetComponent<ItemController>();
        }

        if (this.GetComponent<ShakeObject>() == null)
        {
            ObjectShaker = this.gameObject.AddComponent<ShakeObject>();
        }
        else
        {
            ObjectShaker = this.gameObject.GetComponent<ShakeObject>();
        }
    }
    void Update()
    {
        if (Input.GetButtonDown(triggerInput))
        {
            var player = PlayerSetup.instance.Player.transform;
            var distanceToPlayer = Vector3.Distance(player.position, this.gameObject.transform.position);
            if (distanceToPlayer < destroyRadius)
                OnActivate();
        }
    }

    public override void OnActivate()
    {
        if (triggered) { return; }
        triggered = true;
        DamageObject();
        // Suggestion: check if melee cooldown is done.

        // Shake object visually
        ObjectShaker.Shake(ShakeDuration);
 
        triggered = false;
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

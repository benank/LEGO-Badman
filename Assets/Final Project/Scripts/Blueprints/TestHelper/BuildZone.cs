using Interactable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildZone : TriggeredAction
{
    [SerializeField] private string BlueprintName;
    [SerializeField] private Transform BlueprintTransform;
    [SerializeField] private GameObject BlueprintPrefab;
    
    private TriggerType triggerType = TriggerType.Instant;
    private bool triggered = false;
    private bool playerInTriggerZone = false;

    private void Awake()
    {
        if (this.GetComponent<EventController>() != null)
        {
            this.gameObject.GetComponent<EventController>().Event1 = OnActivate;
        }

        var colliderSubscriber = gameObject.GetComponentInChildren<IColliderSubscriber<Collider, bool>>();
        if (colliderSubscriber != null)
        {
            colliderSubscriber.callbackEvent += OnTriggerEnterExit;
        }
    }
    void OnTriggerEnterExit(Collider other, bool entered)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTriggerZone = entered;
        }
    }
    public bool BuildHere()
    {
        var Player = PlayerSetup.instance.Player;
        var PlayerBlueprintManager = Player.GetComponent<BlueprintController>();

        PlayerBlueprintManager.SetCurrentBlueprint(BlueprintName, BlueprintPrefab);
        return PlayerBlueprintManager.BuildBlueprint();
    }

    public override void OnActivate()
    {

        if (!playerInTriggerZone)
            return;

        if (triggered) { return; }
        triggered = true;

        if (BuildHere())
        {
            foreach (TriggerableAction trigger in triggeredActions)
            {
                trigger.onActivate.Invoke(new TriggerData(triggerType, triggered, triggered ? 1f : 0f));
            }
            this.gameObject.SetActive(false);
        }
        else
        {
            triggered = false;
        }
    }
}

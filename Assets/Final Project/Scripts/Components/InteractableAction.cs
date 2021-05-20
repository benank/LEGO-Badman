using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace Interactable
{
    /// <summary>
    /// Type of event that triggers this component's action.
    /// The Player must complete this trigger to activate the action.
    /// </summary>
    public enum TriggerType
    {
        Instant,
        Continuous
    }
    
    public class TriggerData
    {
        public TriggerType triggerType;
        public bool pressed;
        public float pressedAmount;
        
        public TriggerData(TriggerType triggerType, bool pressed, float pressedAmount)
        {
            this.triggerType = triggerType;
            this.pressed = pressed;
            this.pressedAmount = pressedAmount;
        }
    }
    
    [System.Serializable]
    public class TriggerableAction : MonoBehaviour
    {
        public Action<TriggerData> onActivate;
    }

    public abstract class TriggeredAction : MonoBehaviour
    {
        /// <summary>
        /// List of triggerable actions that will be activated when the lever is pulled.
        /// </summary>
        [SerializeField] protected List<TriggerableAction> triggeredActions = new List<TriggerableAction>();
        
        /// <summary>
        /// Call this when this object is activated, such as a lever.
        /// </summary>
        public abstract void OnActivate();
    }
}

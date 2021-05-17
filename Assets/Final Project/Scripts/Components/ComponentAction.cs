using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Component
{
    /// <summary>
    /// Type of event that triggers this component's action.
    /// The Player must complete this trigger to activate the action.
    /// </summary>
    public enum TriggerType
    {
        Input, // Player presses a button when near the Component
        Area, // Player enters a trigger area
        Destruction, // Player destroys an object
        Inventory // Player obtains X item(s) in inventory
        // Potentially also include cases for killing enemies
    }
    
    public enum ActionType
    {
        
    }
    
    public interface IComponent
    {
        void Activate();
    }
    
    public class Action : MonoBehaviour
    {
        
    }
}

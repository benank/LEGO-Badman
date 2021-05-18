using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public class Button : TriggeredAction
    {
        // [SerializeField] private float pressTime = 
        
        private TriggerType triggerType = TriggerType.Input;
        
        private bool pressed = false;
        private float pressedAmount = 0f;
        
        
        void Update()
        {
            if (pressed && pressedAmount < 1f)
            {
                OnPressedUpdate();
            }
            else if (!pressed && pressedAmount > 0f)
            {
                
            }
        }
        
        void OnPressedUpdate()
        {
            
        }
        
        /// <summary>
        /// For the button, OnActivate is continuously called while the button is pressed.
        /// </summary>
        public override void OnActivate()
        {
            
        }
    }
}

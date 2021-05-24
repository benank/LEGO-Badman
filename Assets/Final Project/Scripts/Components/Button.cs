using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public class Button : TriggeredAction
    {
        [Tooltip("How quickly the button to recesses completely when stepped on")]
        [SerializeField] private float pressTime = 1f;
        
        [Tooltip("Tags of GameObjects that are allowed to trigger the button")]
        [SerializeField] private List<string> triggerTags = new List<string>();
        
        private TriggerType triggerType = TriggerType.Continuous;
        
        private float pressedAmount = 0f;
        
        private List<GameObject> gameObjectsPressing = new List<GameObject>();
        private Vector3 originalPosition;
        private float pressedRecessAmount = -0.34f;
        
        void Awake()
        {
            var colliderSubscriber = gameObject.GetComponentInChildren<IColliderSubscriber<Collider, bool>>();
            if (colliderSubscriber != null)
            {
                colliderSubscriber.callbackEvent += OnTriggerEnterExit;
            }
            
            originalPosition = transform.position;
        }
        
        bool isPressed()
        {
            return gameObjectsPressing.Count > 0;
        }
        
        void Update()
        {
            if (isPressed() && pressedAmount < pressTime)
            {
                OnPressedUpdate(true);
            }
            else if (!isPressed() && pressedAmount > 0f)
            {
                OnPressedUpdate(false);
            }
        }
        
        void OnPressedUpdate(bool increasing)
        {
            if (increasing)
            {
                pressedAmount = Mathf.Min(pressTime, pressedAmount + Time.deltaTime);
            }
            else
            {
                pressedAmount = Mathf.Max(0, pressedAmount - Time.deltaTime);
            }
            
            transform.position = originalPosition + new Vector3(0, pressedRecessAmount * pressedAmount / pressTime, 0);
            OnActivate();
        }
        
        void OnTriggerEnterExit(Collider other, bool entered)
        {
            if (triggerTags.Contains(other.gameObject.tag))
            {
                if (entered)
                {
                    gameObjectsPressing.Add(other.gameObject);
                }
                else
                {
                    gameObjectsPressing.Remove(other.gameObject);
                }
            }
        }
        
        /// <summary>
        /// Called every frame that the button is being pressed or unpressed (not when static)
        /// </summary>
        public override void OnActivate()
        {
            foreach (TriggerableAction trigger in triggeredActions)
            {
                trigger.onActivate.Invoke(new TriggerData(triggerType, isPressed(), pressedAmount / pressTime, gameObject));
            }
        }
    }
}

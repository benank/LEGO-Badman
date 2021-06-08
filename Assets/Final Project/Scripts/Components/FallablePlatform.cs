using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public class FallablePlatform : TriggeredAction
    {
        [Tooltip("Tags of GameObjects that are allowed to trigger the button")]
        [SerializeField] private List<string> triggerTags = new List<string>();

        private TriggerType triggerType = TriggerType.Continuous;

        private List<GameObject> gameObjectsPressing = new List<GameObject>();

        void Awake()
        {
            var colliderSubscriber = gameObject.GetComponentInChildren<IColliderSubscriber<Collider, bool>>();
            if (colliderSubscriber != null)
            {
                colliderSubscriber.callbackEvent += OnTriggerEnterExit;
            }

        }

        bool isPressed()
        {
            return gameObjectsPressing.Count > 0;
        }

        void Update()
        {
            if (isPressed())
            {
                OnPressedUpdate(true);
            }
            else if (!isPressed())
            {
                OnPressedUpdate(false);
            }
        }

        void OnPressedUpdate(bool increasing)
        {
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
                trigger.onActivate.Invoke(new TriggerData(triggerType, isPressed(), 1, gameObject));
            }
        }
    }
}

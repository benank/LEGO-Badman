using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Minifig;

namespace Interactable
{
    public class Lever : TriggeredAction
    {
        [Tooltip("Name of the input button/key that should activate the lever.")]
        [SerializeField] private string triggerInput = "Activate";
        
        [Tooltip("Whether or not this lever can be pulled multiple times or if it is a one time only use.")]
        [SerializeField] private bool oneTimeUse = false;
        
        [Tooltip("Delay before the lever resets to its original position after being pulled. If it is a one time use, it will not reset.")]
        [Range(1, 20)]
        [SerializeField] private float resetTime = 2f;
        
        private TriggerType triggerType = TriggerType.Input;
        
        private Animator animator;
        private bool triggered = false;
        private bool playerInTriggerZone = false;
        
        void Awake()
        {
            animator = GetComponent<Animator>();
            
            var colliderSubscriber = gameObject.GetComponentInChildren<IColliderSubscriber<Collider, bool>>();
            if (colliderSubscriber != null)
            {
                colliderSubscriber.callbackEvent += OnTriggerEnterExit;
            }
        }
        
        void Update()
        {
            if (Input.GetButtonDown(triggerInput) && playerInTriggerZone)
            {
                OnActivate();
            }
        }
        
        void OnTriggerEnterExit(Collider other, bool entered)
        {
            if (other.gameObject.tag == "Player")
            {
                playerInTriggerZone = entered;
            }
        }
        
        public override void OnActivate()
        {
            if (triggered) {return;}
            triggered = true;
            OnActivated();
            
            animator.Play("LeverPullAnimation");
            
            var minifigController = FindObjectOfType<MinifigController>();
 
            if (minifigController)
            {
                // Disable player input to the Minifig so that its animation won't be interrupted
                minifigController.SetInputEnabled(false);

                // Play the Minifig animation
                minifigController.PlaySpecialAnimation(MinifigController.SpecialAnimation.Wave, null, EnableMinifigInput);

                // Re-enable player input to the Minifig
                void EnableMinifigInput(bool b)
                {
                    minifigController.SetInputEnabled(true);
                }
            }
            
            if (!oneTimeUse)
            {
                StartCoroutine(ResetCoroutine());
            }
        }
        
        void OnActivated()
        {
            foreach (TriggerableAction trigger in triggeredActions)
            {
                trigger.onActivate.Invoke(new TriggerData(triggerType, triggered, triggered ? 1f : 0f));
            }
        }
        
        IEnumerator ResetCoroutine()
        {
            yield return new WaitForSeconds(resetTime);
            animator.Play("LeverPullReverse");
            // TODO: QoL - wait for the animation to finish before allowing it to be triggered again
            triggered = false;
            OnActivated();
        }
    }
}
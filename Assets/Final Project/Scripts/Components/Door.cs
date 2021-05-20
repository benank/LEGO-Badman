using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public class Door : TriggerableAction
    {
        [Tooltip("Offset that the door moves when it is fully open")]
        [SerializeField] private Vector3 doorOpenOffset = Vector3.zero;
        
        [Tooltip("Offset that the door rotates when it is fully open")]
        [SerializeField] private Vector3 doorOpenRotation = Vector3.zero;
        
        [Tooltip("Animation curve in case you don't want a simple linear open motion")]
        [SerializeField] private AnimationCurve doorOpenCurve = AnimationCurve.Linear(0, 0, 1, 1);
        
        private Vector3 originalPosition;
        private Vector3 originalRotation;
        
        private float pressedAmount = 0f;
        
        void Awake()
        {
            this.onActivate = delegate (Interactable.TriggerData td)
            {
                Triggered(td);
            };
            
            originalPosition = transform.position;
            originalRotation = transform.rotation.eulerAngles;
        }
        
        public void Triggered(Interactable.TriggerData td)
        {
            if (td.triggerType == Interactable.TriggerType.Instant)
            {
                StartCoroutine(LerpToPressedAmount(td.pressedAmount));
            }
            else
            {
                pressedAmount = td.pressedAmount;
                UpdateDoor();
            }
        }
        
        void UpdateDoor()
        {
            float percentComplete = doorOpenCurve.Evaluate(pressedAmount);
            
            this.transform.position = originalPosition + percentComplete * doorOpenOffset;
            this.transform.rotation = Quaternion.Euler(originalRotation + percentComplete * doorOpenRotation);
        }
        
        IEnumerator LerpToPressedAmount(float td_pressedAmount)
        {
            while (pressedAmount != td_pressedAmount)
            {
                pressedAmount += pressedAmount < td_pressedAmount ? Time.deltaTime : -Time.deltaTime;
                pressedAmount = Mathf.Clamp(pressedAmount, 0, 1);
                UpdateDoor();
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
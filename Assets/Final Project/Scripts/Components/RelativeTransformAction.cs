using System.Collections;
using UnityEngine;

namespace Interactable
{
    public class RelativeTransformAction : TriggerableAction
    {

        [Tooltip("Position (Relative) to move by.")]
        [SerializeField] private Vector3 positionOffset = Vector3.zero;

        [Tooltip("Rotation (Relative) to rotate by.")]
        [SerializeField] private Vector3 rotationOffset = Vector3.zero;

        [Tooltip("Animation curve in case you don't want a simple linear open motion")]
        [SerializeField] private AnimationCurve transformCurve = AnimationCurve.Linear(0, 0, 1, 1);

        [Tooltip("Time needed to perform transformation in seconds")]
        [SerializeField] private float timeNeeded = 2f;

        [Tooltip("If true, activate action.")]
        [SerializeField] private bool isActive = true;

        [Tooltip("If true, on next trigger revert changes made to transform.")]
        [SerializeField] private bool reverseOnComplete = false;

        [Tooltip("If true, subtract from local transform instead of addition.")]
        private bool isReversed = false;

        private Vector3 originalPosition;
        private Vector3 originalRotation;
        private bool isMoving = false;

        void Awake()
        {
            this.onActivate = delegate (TriggerData td)
            {
                Triggered(td);
            };
        }

        public void Triggered(TriggerData td)
        {
            if (td.triggerType == TriggerType.Instant && td.pressed)
            {
                StartCoroutine(LerpToNewTransform());
            }
        }
        IEnumerator LerpToNewTransform()
        {
            if (!isMoving && isActive)
            {
                isMoving = true;
                originalPosition = this.gameObject.transform.localPosition;
                originalRotation = this.gameObject.transform.localEulerAngles;

                float timeTaken = 0f;
                while (timeTaken <= timeNeeded)
                {
                    timeTaken += Time.deltaTime;
                    var ratio = Mathf.Clamp((timeTaken / timeNeeded), 0f, 1f);

                    float percentComplete = transformCurve.Evaluate(ratio);

                    if (!isReversed)
                    {
                        this.transform.localPosition = originalPosition + (percentComplete * positionOffset);
                        this.transform.localRotation = Quaternion.Euler(originalRotation + (percentComplete * rotationOffset));
                    }
                    else
                    {
                        this.transform.localPosition = originalPosition - (percentComplete * positionOffset);
                        this.transform.localRotation = Quaternion.Euler(originalRotation - (percentComplete * rotationOffset));
                    }

                    yield return new WaitForEndOfFrame();
                }
                if (reverseOnComplete)
                {
                    isReversed = !isReversed;
                }
                isMoving = false;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Minifig;

namespace Combat
{

    public enum MeleeTypes
    {
        SwordLunge = 0,
        SwordWideSwing = 1,
        SwordReverseWideSwing = 2
    }

    public class CombatController : MonoBehaviour
    {
        private Animator animator;
        [SerializeField] private AudioClip LungeSound;
        [SerializeField] private AudioClip SwingSound;
        [SerializeField] private AudioClip ReverseSwingSound;
        private AudioSource audioSource;
        private float meleeCooldown = 0;
        private float currentAttackDuration = 0;
        private float swordLungeDuration;
        private float swordSwipeDuration;
        private float swordReverseSwipeDuration;
        

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            AnimationClip[] clips =  animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                switch (clip.name)
                {
                    case "SwordLungeAnimation":
                        swordLungeDuration = clip.length;
                        break;
                    case "OneHandedReverseSwordSwingAnimation":
                        swordReverseSwipeDuration = clip.length;
                        break;
                    case "OneHandedSwordSwingAnimation":
                        swordSwipeDuration = clip.length;
                        break;
                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            // Check if an attack is still being done.
            if (meleeCooldown <= currentAttackDuration)
            {
                meleeCooldown += Time.deltaTime;
                return;
            }
                
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var values = Enum.GetValues(typeof(MeleeTypes));
                int random = UnityEngine.Random.Range(0, values.Length);
                MeleeTypes melee = (MeleeTypes)values.GetValue(random);
                meleeCooldown = 0;
                switch (melee)
                {
                    case MeleeTypes.SwordLunge:
                        animator.Play("SwordLungeAnimation");
                        audioSource.PlayOneShot(LungeSound);
                        currentAttackDuration = swordLungeDuration;
                        break;
                    case MeleeTypes.SwordReverseWideSwing:
                        animator.Play("OneHandedReverseSwordSwingAnimation");
                        audioSource.PlayOneShot(ReverseSwingSound);
                        currentAttackDuration = swordReverseSwipeDuration;
                        break;
                    case MeleeTypes.SwordWideSwing:
                        animator.Play("OneHandedSwordSwingAnimation");
                        audioSource.PlayOneShot(SwingSound);
                        currentAttackDuration = swordSwipeDuration;
                        break;
                }
            }
        }
    }

}

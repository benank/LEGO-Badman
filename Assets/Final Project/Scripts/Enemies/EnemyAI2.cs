using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace Unity.LEGO.Minifig
{
    public class EnemyAI2 : MonoBehaviour
    {
        public float chasedistance;
        public float attackdistance;
        public Slider healthbar;
        public bool hidehealthbar;
        private Transform player;
        private Animator animator;
        private MinifigController minifig;
        public Transform[] points;
        private int current;
        private float maxhealth = 3;
        private float health = 3;
        private bool dead;

        private float meleeCooldown = 0;
        private float swordSwipeDuration;
        private float swordReverseSwipeDuration;
        private float currentAttackDuration = 0;

        void Awake()
        {
            // Get information about enemy and player.
            player = GameObject.FindWithTag("Player").transform;
            animator = GetComponent<Animator>();
            minifig = GetComponent<Unity.LEGO.Minifig.MinifigController>();

            if (hidehealthbar)
            {
                healthbar.gameObject.SetActive(false);
            }
            else
            {
                healthbar.value = health / maxhealth;
            }

            // Make enemy alive.
            dead = false;

            AnimationClip[] clips =  animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                switch (clip.name)
                {
                    case "OneHandedReverseSwordSwingAnimation":
                        swordReverseSwipeDuration = clip.length;
                        break;
                    case "OneHandedSwordSwingAnimation":
                        swordSwipeDuration = clip.length;
                        break;
                }
            }
        }

        void Update()
        {

            if (meleeCooldown < currentAttackDuration)
            {
                meleeCooldown += Time.deltaTime;
                return;
            }

            // Update healthbar.
            healthbar.value = health / maxhealth;

            // If the enemies health is at zero, play animation, wait and destroy.
            if (health <= 0 && dead == false)
            {
                animator.Play("Sleeping");
                dead = true;
                StartCoroutine(Wait());
            }

            // If enemy is dead, do not do any actions.
            if (dead == false)
            {
                float dist = Vector3.Distance(minifig.transform.position, player.position);
                if (dist <= chasedistance && dist > attackdistance)
                {
                    // If player is within chase distance, enemy will chase player.
                    ChasePlayer();
                }
                else if (dist <= attackdistance)
                {
                    // If player is within attack distance, enemy will attack player.
                    AttackPlayer();
                }
                else
                {
                    // Otherwise, patrol.
                    Patrol();
                }
            }
            
        }

        IEnumerator Wait()
        {
            // Wait for 2 seconds for death animation to play, then destroy.
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
        private void Patrol()
        {
            // Move the Minifig and update position index.
            // minifig.SpecialAnimationFinished();
            minifig.StopFollowing();
            minifig.MoveTo(points[current].position);
            current = (current + 1) % points.Length;
        }

        private void ChasePlayer()
        {
            // Enemy will follow the player until enemy reaches attack distance.
            // minifig.SpecialAnimationFinished();
            minifig.Follow(player);
        }

        private void AttackPlayer()
        {
            // Enemy will stop following the player, will stop moving and attack.
            minifig.StopFollowing();
            minifig.ClearMoves();
            meleeCooldown = 0;
            animator.Play("EnemyOneHandedSwordSwingAnimation");
            currentAttackDuration = swordSwipeDuration;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && health > 0);
            {
                // Player collider trigger, decrease health.
                health = health - 1;
            }
        }
    }
}

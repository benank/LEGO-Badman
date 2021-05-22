using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Unity.LEGO.Minifig
{
    public class EnemyAI2 : MonoBehaviour
    {
        public float chasedistance;
        public float attackdistance;
        private Transform player;
        // private Animation attack;
        private MinifigController minifig;

        public Transform[] points;
        int current;

        void Awake()
        {
            player = GameObject.FindWithTag("Player").transform;
            // attack = gameObject.GetComponent<Animation>();
            minifig = GetComponent<Unity.LEGO.Minifig.MinifigController>();
        }

        void Update()
        {
            float dist = Vector3.Distance(minifig.transform.position, player.position);

            // if (attack.isPlaying)
            // {
            //     return;
            // }
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

        private void Patrol()
        {
            // Move the Minifig and update position index.
            minifig.MoveTo(points[current].position);
            current = (current + 1) % points.Length;
        }

        private void ChasePlayer()
        {
            // Enemy will follow the player until enemy reaches attack distance.
            minifig.Follow(player);
        }

        private void AttackPlayer()
        {
            // Enemy will stop following the player, will stop moving and attack.
            minifig.StopFollowing();
            minifig.ClearMoves();
            Debug.Log("attack");
        }
    }
}

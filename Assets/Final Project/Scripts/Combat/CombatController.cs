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
        [SerializeField] private GameObject weapon;
        private float hitRate = 1.0f;
        private Animator animator;
        private MinifigController minifigController;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            minifigController = GetComponent<MinifigController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var values = Enum.GetValues(typeof(MeleeTypes));
                int random = UnityEngine.Random.Range(0, values.Length);
                MeleeTypes melee = (MeleeTypes)values.GetValue(random);
                switch (melee)
                {
                    case MeleeTypes.SwordLunge:
                        animator.Play("SwordLungeAnimation");
                        break;
                    case MeleeTypes.SwordReverseWideSwing:
                        animator.Play("OneHandedReverseSwordSwingAnimation");
                        break;
                    case MeleeTypes.SwordWideSwing:
                        animator.Play("OneHandedSwordSwingAnimation");
                        break;
                }
            }
        }
    }

}

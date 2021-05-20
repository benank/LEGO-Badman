using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    [RequireComponent(typeof(Rigidbody))]
    public class PushableRock : MonoBehaviour
    {
        [SerializeField] private float force = 25f;
        
        private Rigidbody _rigidbody;
        
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Vector3 pos1 = transform.position;
                Vector3 pos2 = other.gameObject.transform.position;
                pos2.y = pos1.y;
                Vector3 direction = (transform.position - other.gameObject.transform.position).normalized;
                _rigidbody.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }
}

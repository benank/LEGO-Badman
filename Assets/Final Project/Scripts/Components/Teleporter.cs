using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactable
{
    public class Teleporter : TriggerableAction
    {
        [Tooltip("Teleporter that this will teleport to")]
        [SerializeField] private Teleporter linkedTeleporter;
        
        [Tooltip("Tags of GameObjects that are allowed to trigger the teleporter")]
        [SerializeField] private List<string> triggerTags = new List<string>();
        
        [Tooltip("Whether or not the teleporter is active and can teleport or not. If attached to an interactable, like a lever or button, it will be activated/deactivated when those are pressed.")]
        [SerializeField] private bool isActive = true;

        [SerializeField] private GameObject particleEffects;
        [SerializeField] private GameObject particleEffectsTrail;

        private AudioSource audioSource;
        /// <summary>
        /// The teleport location attached to this teleporter.
        /// </summary>
        protected Transform teleportLocation;
        
        private List<GameObject> recentTeleports = new List<GameObject>();

        // Start is called before the first frame update
        private void Awake()
        {
            this.onActivate = delegate (Interactable.TriggerData td)
            {
                Triggered(td);
            };
        }
        void Start()
        {
            if (linkedTeleporter == null)
            {
                Debug.LogWarning($"No linkedTeleported specified for teleporter. Make sure to assign it in the inspector.");
            }
            
            teleportLocation = transform.Find("Teleport Location");
            
            var colliderSubscriber = gameObject.GetComponentInChildren<IColliderSubscriber<Collider, bool>>();
            if (colliderSubscriber != null)
            {
                colliderSubscriber.callbackEvent += OnTriggerEnterExit;
            }

            audioSource = GetComponent<AudioSource>();
        }
        
        public void AddRecentlyTeleportedGameObject(GameObject go)
        {
            recentTeleports.Add(go);
        }

        public void RemoveRecentlyTeleportedGameObject(GameObject go)
        {
            recentTeleports.Remove(go);
        }

        void OnTriggerEnterExit(Collider other, bool entered)
        {
            if (triggerTags.Contains(other.gameObject.tag) && isActive && entered && !recentTeleports.Contains(other.gameObject))
            {
                GameObjectEnteredTrigger(other.gameObject);
            }
        }
        
        void GameObjectEnteredTrigger(GameObject go)
        {
            if (linkedTeleporter == null) {return;}
            
            StartCoroutine(TeleportCoroutine(go));
        }
        
        IEnumerator TeleportCoroutine(GameObject go)
        {
            go.SetActive(false);
            SpawnParticleEffects(go);

            StartCoroutine(SpawnTrailFX(go.transform, linkedTeleporter.teleportLocation));
            linkedTeleporter.AddRecentlyTeleportedGameObject(go);
            audioSource.Play();
            yield return new WaitForSeconds(0.25f);
            go.transform.position = linkedTeleporter.teleportLocation.position;
            audioSource.Play();
            yield return new WaitForSeconds(0.25f);
            go.SetActive(true);
            SpawnParticleEffects(go);
            yield return new WaitForSeconds(0.25f);
            linkedTeleporter.RemoveRecentlyTeleportedGameObject(go);
        }

        IEnumerator SpawnTrailFX(Transform origin, Transform target)
        {
            GameObject pfx = GameObject.Instantiate(
                particleEffectsTrail, 
                origin.transform.position, 
                origin.transform.rotation);
            
            float time_to_complete = 0.25f;
            float progress = 0f;
            float step = 0.01f;

            while (progress < time_to_complete)
            {
                progress += step;
                pfx.transform.position = Vector3.Lerp(origin.position, target.position, progress / time_to_complete);
                yield return new WaitForSeconds(step);
            }

            Destroy(pfx, 1f);
        }

        void SpawnParticleEffects(GameObject origin)
        {
            GameObject pfx = GameObject.Instantiate(
                particleEffects, 
                origin.transform.position, 
                origin.transform.rotation);
            
            Destroy(pfx, 1);
        }

        public void Triggered(TriggerData td)
        {
            if (td.pressed)
            {
                isActive = !isActive;
            }
        }
    }
}
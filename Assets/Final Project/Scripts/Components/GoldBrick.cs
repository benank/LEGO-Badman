using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class GoldBrick : MonoBehaviour
{
    [SerializeField] private float translationSpeed;
    [SerializeField] private float translationAmount;
    
    [SerializeField] private float rotationSpeed;
    
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private bool gotBrick = false;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.zero;
        position.y += Mathf.Sin(Time.time * translationSpeed) * translationAmount;
        transform.position = originalPosition + position;
        
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, Time.time * rotationSpeed, 0);
        transform.rotation = originalRotation * rotation;

        if (gotBrick)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player got gold brick");
            
            // Trigger game win event
            Unity.LEGO.Game.Events.GameOverEvent.Win = true;
            Unity.LEGO.Game.EventManager.Broadcast(Unity.LEGO.Game.Events.GameOverEvent);
            StartCoroutine(LoadLevelComplete());
            gotBrick = true;
            // To subscribe to events, use the following code:
            /*
                Unity.LEGO.Game.EventManager.AddListener<GameOverEvent>(OnGameOver);
                ...
                void OnGameOver(GameOverEvent evt) {}
            */
        }
    }

    IEnumerator LoadLevelComplete()
    {
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("LevelComplete");
        Destroy(this.gameObject);
    }
}

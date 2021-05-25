using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GoldBrick : MonoBehaviour
{
    [SerializeField] private float translationSpeed;
    [SerializeField] private float translationAmount;
    
    [SerializeField] private float rotationSpeed;
    
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
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
    }
}

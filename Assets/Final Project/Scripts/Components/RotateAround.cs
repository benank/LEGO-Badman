using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform rotatePoint;
    [SerializeField] private float speed = 1f;
    
    private float timeElapsed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotatePoint.position, Vector3.up, timeElapsed * speed);
        timeElapsed += Time.deltaTime;
    }
}

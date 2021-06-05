using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBrain : MonoBehaviour
{
    private GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        playerCamera = GameObject.Find("Third Person Free Look Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCamera.transform);
    }
}

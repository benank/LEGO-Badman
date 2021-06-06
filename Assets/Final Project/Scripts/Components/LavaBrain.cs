using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBrain : MonoBehaviour
{    
    [SerializeField] public float LavaRisingRate;
    [SerializeField] public bool IsRising;
    private GameObject lava;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        lava = GameObject.Find("Lava");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRising)
        {
            lava.transform.position += new Vector3(0.0f, LavaRisingRate * Time.deltaTime, 0.0f);
        }
    }
}

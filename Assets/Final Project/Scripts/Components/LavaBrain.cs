using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBrain : MonoBehaviour
{    
    [SerializeField] public float LavaRisingRate;
    [SerializeField] public bool IsRising;
    [SerializeField] private float RiseDistance;
    private Vector3 riseStopPoint;
    private GameObject lava;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        lava = GameObject.Find("Lava");
        riseStopPoint = transform.position + new Vector3(0.0f, RiseDistance, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRising)
        {
            Vector3 rise = new Vector3(0.0f, LavaRisingRate * Time.deltaTime, 0.0f);
            if (lava.transform.position.y + rise.y >= riseStopPoint.y)
            {
                IsRising = false;
                lava.transform.position = riseStopPoint;
            }
            else
            {
                lava.transform.position += new Vector3(0.0f, LavaRisingRate * Time.deltaTime, 0.0f);
            }
        }
    }

    public void ChangeRiseSpeed(float speed)
    {
        LavaRisingRate = speed;
    }

    public void IncrementRiseSpeed(float speed)
    {
        LavaRisingRate += speed;
    }
}

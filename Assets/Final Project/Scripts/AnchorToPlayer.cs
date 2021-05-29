using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        var position = player.transform.position;
        position.Set(position.x + offset.x, position.y + offset.y, position.z + offset.z);
        this.gameObject.transform.SetPositionAndRotation(position, player.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        var position = player.transform.position;
        position.Set(position.x + offset.x, position.y + offset.y, position.z + offset.z);
        this.gameObject.transform.SetPositionAndRotation(position, player.transform.rotation);
    }
}

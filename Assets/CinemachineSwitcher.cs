using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator animator;
    [SerializeField] CinemachineFreeLook camera;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    // void Start()
    // {
    //     var player = GameObject.FindGameObjectWithTag("Player");
    //     // camera = GameObject.FindGameObjectWithTag("Camera");
    //     var controller = player.GetComponent<Unity.LEGO.Minifig.MinifigController>();
    //     if (ICinemachineCamera.IsLiveChild(camera)) 
    //     {
    //         controller.SetInputEnabled(true); // true or false
    //     }
    //     else 
    //     {
    //         controller.SetInputEnabled(false); // true or false
    //     }
        

    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}

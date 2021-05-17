using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TestLeverAnimation : MonoBehaviour
{
    private Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        
        StartCoroutine(Animate());
    }
    
    IEnumerator Animate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            animator.Play("LeverPullAnimation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

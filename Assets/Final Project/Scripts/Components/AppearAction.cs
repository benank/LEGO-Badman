using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearAction : Interactable.TriggerableAction
{
    [Tooltip("Initial state of the GameObject - set to true to initially hide the object")]
    [SerializeField] private bool isInitiallyHidden = true;
    
    private bool isHidden;

    [Tooltip("If true, next trigger will toggle the visibility.")]
    [SerializeField]
    private bool toggleVisibility = false;

    void Start()
    {
        this.onActivate = delegate (Interactable.TriggerData td)
        {
            Triggered(td);
        };
        
        isHidden = isInitiallyHidden;
        gameObject.SetActive(!isHidden);
    }

    void Triggered(Interactable.TriggerData td)
    {
        if (toggleVisibility && td.pressedAmount == 1)
        {
            isHidden = !isHidden;
            gameObject.SetActive(!isHidden);
        }
        else
        {
            isHidden = td.pressedAmount == 0;
            gameObject.SetActive(!isHidden);
        }
    }
    
}

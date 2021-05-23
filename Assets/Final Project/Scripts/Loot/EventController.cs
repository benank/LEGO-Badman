using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public delegate void EventDelegate();
    public EventDelegate EventMethod;
    public void TriggerEvent()
    {
        EventMethod();
        return;
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public delegate void EventDelegate();
    public EventDelegate Event1;
    public EventDelegate Event2;
    public void TriggerEvent1()
    {
        // On Left Click
        Event1();
    }
    public void TriggerEvent2()
    {
        // On Right Click
        Event2();
    }

}

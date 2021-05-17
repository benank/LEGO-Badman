using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Interactable
{
    /// <summary>
    /// Interface class for a Collider subscriber to listen to collision events. Q is true on enter, false on exit.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Q"></typeparam>
    public interface IColliderSubscriber<T, Q>
    {
        event Action<T, Q> callbackEvent;
    }

    public class TriggerCallback : MonoBehaviour, IColliderSubscriber<Collider, bool>
    {
        public event Action<Collider, bool> callbackEvent;
        
        void OnTriggerEnter(Collider other)
        {
            if (callbackEvent != null)
            {
                callbackEvent.Invoke(other, true);
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (callbackEvent != null)
            {
                callbackEvent.Invoke(other, false);
            }
        }
    }

}
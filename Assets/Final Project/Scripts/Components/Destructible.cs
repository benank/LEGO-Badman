using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private float health;
    
    /// <summary>
    /// Call this function with a damage amount to damage the object. Once the object's health hits 0, it will be destroyed.
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        if (health == 0) {return;}
        
        health = Mathf.Max(0, health - damage);
        
        if (health == 0)
        {
            Destroyed();
        }
    }
    
    void Destroyed()
    {
        // TODO: spawn loot and create destruction FX
        // Super basic for now
        Destroy(this.gameObject);
    }
}

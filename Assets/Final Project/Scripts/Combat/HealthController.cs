using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private bool hideHealthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;
    [SerializeField] private float healthRegenRate;
    [SerializeField] private float healthRegenDelay;
    private float currentRegenDelay;
    [SerializeField] private Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        currentRegenDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update healthbar.
        healthBar.value = currentHealth / maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWeapon" && currentHealth > 0)
        {
            // Player collider trigger, decrease health.
            currentHealth = currentHealth - 1;
        }
    }
}

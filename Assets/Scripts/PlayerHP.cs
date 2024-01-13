using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // For demonstration purposes, reduce health over time
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    // Call this method from your enemy script when they attack
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0 or above maxHealth
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            // Handle player death, e.g., restart the level or show game over screen
            // For now, let's just print a message
            Debug.Log("Player has been defeated!");
        }
    }
}
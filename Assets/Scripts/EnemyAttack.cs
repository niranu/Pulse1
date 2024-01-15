using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 20;
    public float normalSpeed = 40f;
    public float boostedSpeed = 45f; // Adjust this value for increased speed when flashlight is on

    private Transform player;
    private bool flashlightActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming the player has a PlayerHealth script attached
            PlayerHP playerHP = other.GetComponent<PlayerHP>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(damage);

                // Set the player as the target
                player = other.transform;
            }
        }
    }

    void Update()
    {
        // Check if the player is set as the target
        if (player != null)
        {
            // Determine the current speed based on the flashlight state
            float currentSpeed = flashlightActive ? boostedSpeed : normalSpeed;

            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);
        }
    }

    // Add this method to toggle the flashlight state
    public void ToggleFlashlight(bool isActive)
    {
        flashlightActive = isActive;
    }
} 


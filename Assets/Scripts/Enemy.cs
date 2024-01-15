using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float normalSpeed = 1f;
    public float flashlightSpeed = 1.8f;
    public int attackDamage = 20;

    private bool isPlayerInRange = false;
    private GameObject player;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            player = other.gameObject;
            animator.SetBool("isPlayerInRange", true);
            // Trigger the roar animation when the player enters the collider
            animator.SetTrigger("roar");
            animator.SetTrigger("walk");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;
            animator.SetBool("isPlayerInRange", false);
        }
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            FlashlightToggle flashlightToggle = GetComponent<FlashlightToggle>();
            if (flashlightToggle != null)
            {
                // Check if flashlight is on
                if (flashlightToggle.lightGO.activeSelf)
                {
                    // Player has flashlight on
                    animator.SetFloat("speed", flashlightSpeed);
                    FollowPlayer(flashlightSpeed);
                }
                else
                {
                    // Player doesn't have flashlight on
                    animator.SetFloat("speed", normalSpeed);
                    FollowPlayer(normalSpeed);
                }
            }
            else
            {
                animator.SetFloat("speed", 0f);

            }
        }
        else
        {
            // Player is not in range, stop animations
            animator.SetFloat("speed", 0f);
        }
    }

    void FollowPlayer(float speed)
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isPlayerInRange && collision.collider.CompareTag("Player"))
        {
            // Player is close to the enemy, apply damage and play attack animation
            PlayerHP playerHealth = player.GetComponent<PlayerHP>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
            animator.SetTrigger("isAttacking");
        }
    }
}
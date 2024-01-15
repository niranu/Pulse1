using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float moveSpeed = 40f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }

        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on the monster GameObject.");
        }
        animator = GetComponent<Animator>(); // Add this line
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the monster GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            if (player != null)
            {
                // Calculate the direction to the player
                Vector3 direction = (player.position - transform.position).normalized;

                // Move towards the player
                transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

                // Set IsWalking parameter based on movement
                animator.SetBool("isWalking", direction.magnitude > 0.1f);

                // Rotate towards the player (optional)
                if (direction.magnitude > 1f)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
                }
            }
        }
    }

    // New method to update the IsWalking parameter
    private void SetIsWalking(bool value)
    {
        if (animator != null)
        {
            animator.SetBool("isWalking", value);
        }
    }
}

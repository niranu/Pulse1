using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Coroutine currentCoroutine;
    GameObject playerObject;
    private NavMeshAgent agent;

    public float detectionRange = 10f;
    private bool isChasing = false;

    public float health = 100f;
    public float chaseSpeed = 5f;
    public float damage = 10f;
    public float attackDelay = 2;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;
        agent.stoppingDistance = 1.1f;

        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(HitPlayer());
        }
    }
    void Update()
    {
        if (playerObject.transform != null)
        {
            float distanceToPlayer = Vector3.Distance(playerObject.transform.position, transform.position);

            if (!isChasing && distanceToPlayer <= detectionRange)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (playerObject.transform.position - transform.position).normalized, out hit, detectionRange))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        isChasing = true;
                    }
                }
            }

            if (isChasing)
            {
                agent.SetDestination(playerObject.transform.position);
            }
        }
        else
        {
            Debug.LogError("Player reference is missing!");
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0) { Die(); }
    }

    private IEnumerator HitPlayer()
    {
        RaycastHit punch;
        if (Physics.Raycast(transform.position, (playerObject.transform.position - transform.position).normalized, out punch, 1))
        {
            if (punch.collider.gameObject.CompareTag("Player"))
            {
                PlayerHP player = punch.collider.gameObject.GetComponent<PlayerHP>();
                if (player != null)
                {
                    player.TakeDamage((int)damage);
                    yield return new WaitForSeconds(attackDelay);
                    currentCoroutine = null;
                }
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
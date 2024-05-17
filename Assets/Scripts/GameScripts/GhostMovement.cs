using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    public Transform[] goals;
    public Transform player;
    private NavMeshAgent agent;
    private int currentGoalIndex;
    public float detectionRadius = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentGoalIndex = 0;
        agent.SetDestination(goals[currentGoalIndex].position);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (agent.remainingDistance <= 0.5f && !agent.pathPending)
            {
                currentGoalIndex = (currentGoalIndex + 1) % goals.Length;
                agent.SetDestination(goals[currentGoalIndex].position);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class WallMovement : MonoBehaviour
{
    public Transform[] goals;
    private NavMeshAgent agent;
    private int currentGoalIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        SetNextDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetNextDestination();
        }
    }

    void SetNextDestination()
    {
        currentGoalIndex = (currentGoalIndex + 1) % goals.Length;
        agent.SetDestination(goals[currentGoalIndex].position);
    }
}

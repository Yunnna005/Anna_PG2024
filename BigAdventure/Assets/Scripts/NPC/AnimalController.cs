using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AnimalState
{
    Idle,
    Moving,
}

[RequireComponent(typeof(NavMeshAgent))]
public class AnimalController : MonoBehaviour
{
    [Header("Wander")]
    public float wanderDistance = 50f;
    public float walkSpeed = 0.4f;
    public float maxWalkTime = 10f;


    [Header("Idle")]
    public float idleTime = 2f;

    internal NavMeshAgent NavMeshAgent;
    internal AnimalState currentState = AnimalState.Idle;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InitialiseAnimal();
    }

    private void InitialiseAnimal()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.speed = walkSpeed;

        currentState = AnimalState.Idle;
        UpdateState();
    }

    private void UpdateState()
    {
        switch (currentState)
        {
            case AnimalState.Idle:
                animator.SetInteger("Walk", 0);
                HandleIdleState();
                break;
            case AnimalState.Moving:
                animator.SetInteger("Walk", 1);
                HandleMovingState();
                break;
        }
    }

    private Vector3 GetRandomNavMeshPosition(Vector3 origin, float distance)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navMeshHit;

        if (NavMesh.SamplePosition(randomDirection, out navMeshHit, distance, NavMesh.AllAreas))
        {
            return navMeshHit.position;
        }
        else
        {
            return GetRandomNavMeshPosition(origin, distance);
        }
    }

    protected virtual void HandleIdleState()
    {
        StartCoroutine(WalkToMove());
    }

    private IEnumerator WalkToMove()
    {
        float waitTime = UnityEngine.Random.Range(idleTime / 2, idleTime + 2);
        yield return new WaitForSeconds(waitTime);

        Vector3 randomDestination = GetRandomNavMeshPosition(transform.position, wanderDistance);

        NavMeshAgent.SetDestination(randomDestination);
        SetState(AnimalState.Moving);
    }

    protected virtual void HandleMovingState()
    {
        StartCoroutine(WaitToReachDestination());
    }

    private IEnumerator WaitToReachDestination()
    {
        float startTime = Time.time;
        while (NavMeshAgent.remainingDistance > NavMeshAgent.stoppingDistance)
        {

            if (Time.time - startTime >= maxWalkTime)
            {
                NavMeshAgent.ResetPath();
                SetState(AnimalState.Idle);
                yield break;
            }

            yield return null;
        }
        SetState(AnimalState.Idle);
    }

    protected void SetState(AnimalState newState)
    {
        if (currentState == newState)
        {
            return;
        }
        else
        {
            currentState = newState;
        }

        OnStateChange(newState);
    }

    protected virtual void OnStateChange(AnimalState animalState)
    {
        UpdateState();
    }
}

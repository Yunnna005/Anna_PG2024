using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    float attackRange = 1;
    float chaseRange = 5;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 4;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        agent.SetDestination(player.transform.position);
        float distance = Vector3.Distance(animator.transform.position, player.transform.position);

        if (distance <= attackRange)
        {
            animator.SetBool("isAttacking", true);
        }

        if (distance > chaseRange)
        {
            animator.SetBool("isChasing", false);
        }
        if (player == null)
        {
            Debug.LogWarning("Player not found.");
            return; // Exit the function to prevent further errors
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 2;
    }

}

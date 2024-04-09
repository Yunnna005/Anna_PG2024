using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBehaviour : StateMachineBehaviour
{

    Transform player;
    PlayerContoller playerController;
    float attackRange = 1;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.gameObject.GetComponent<PlayerContoller>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position, player.transform.position);

        if(distance > attackRange)
        {
            animator.SetBool("isAttacking", false);
        }

        if(playerController.playerHealth <= 0)
        {
            animator.SetBool("isIdling", true);
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

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimPowerAttack : StateMachineBehaviour
{
    GameObject enemy;
    private EnemyAttack ea;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        ea = enemy.GetComponent<EnemyAttack>();

        ea.EnemyIsPowerAttacking = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ea.EnemyIsPowerAttacking = false;
    }
}

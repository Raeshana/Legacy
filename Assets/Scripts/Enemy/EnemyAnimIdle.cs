using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimIdle : StateMachineBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    GameObject enemy;
    private EnemyController ec;
    private EnemyAttack ea;

    private PlayerAttack pa;
    private PlayerBlock pb;
    private PlayerJump pj;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        ea = enemy.GetComponent<EnemyAttack>();
        rb = animator.GetComponent<Rigidbody2D>();
        ec = enemy.GetComponent<EnemyController>();

        pa = player.GetComponent<PlayerAttack>();
        pb = player.GetComponent<PlayerBlock>();
        pj = player.GetComponent<PlayerJump>();
    }

    bool EnemyShouldAttack()
    {
        // if player is within attack scope, and player is not attacking, and is not blocking/about to end blocking
        bool inAttackRange = Mathf.Abs(player.transform.position.x - rb.position.x) < ec.attackRange;

        int p_attack = 1;
        if (pa.getIsAttacking())
        {
            p_attack = UnityEngine.Random.Range(0, 5); //20% change that the enemy will still attack instead of blocking

        }
        return p_attack == 1 && !pb.getIsBlocking() && !pj.getIsJumping() && inAttackRange;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (EnemyShouldAttack())
        {
            if (ea.count != 0)
            {
                animator.SetTrigger("EnemyCanAttack");
            }
            else
            {
                ea.EnemyIsPowerAttacking = true;
                animator.SetTrigger("EnemyCanPowerAttack");
            }
            ea.IncrementCount();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("EnemyCanAttack");
        animator.ResetTrigger("EnemyCanPowerAttack");
    }
}

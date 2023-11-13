using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationIdleToAttack : StateMachineBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    GameObject enemy;
    private EnemyController ec;
    private EnemyAttack ea;

    private PlayerAttack pa;
    private PlayerBlock pb;
    private PlayerJump pj;

    //public int enemyDamage;
    public bool EnemyIsAttacking = false;
    public bool EnemyIsPowerAttacking = false;
    public int cooling;
    public int count;

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
        return !pb.getIsBlocking() && !pj.getIsJumping() && !pa.getIsAttacking() && inAttackRange;
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

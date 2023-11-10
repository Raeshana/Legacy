using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController ec;
    public GameObject player;
    public Animator anim;

    private readonly PlayerAttack pa;
    private PlayerBlock pb;
    private PlayerJump pj;
    private PlayerHurt phurt;


    public bool EnemyIsAttacking = false;
    public int cooling;

    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponent<EnemyController>();
        pb = player.GetComponent<PlayerBlock>();
        pj = player.GetComponent<PlayerJump>();
        phurt = player.GetComponent<PlayerHurt>();
        cooling = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(EnemyShouldAttack());
        if (EnemyShouldAttack() && cooling == 0
            && !ec.EnemyIsJumping && !ec.EnemyIsMoving && !ec.EnemyIsBlocking)
        {
            Debug.Log("2");

            AttackRoutine();
        }
    }

    bool EnemyShouldAttack()
    {
        // to do
        // if player is within attack scope, and player is not attacking, and is not blocking/about to end blocking
        Debug.Log("1");
        //Debug.Log(pb.getIsBlocking());
        //Debug.Log(pj.getIsJumping());
        Debug.Log(pa.getIsAttacking());
        Debug.Log(ec.horizontalDistanceBtw);
        Debug.Log(ec.attackRange);
        return !pb.getIsBlocking() && !pj.getIsJumping() && !pa.getIsAttacking() && ec.horizontalDistanceBtw < ec.attackRange;
    }

    void AttackRoutine()
    {
        Debug.Log("3");

        EnemyIsAttacking = true;
        anim.SetTrigger("EnemyCanAttack");
        anim.SetBool("EnemyIsAttacking", true);
        Attack();
        EnemyIsAttacking = false;
        anim.SetBool("EnemyIsAttacking", false);
        cooling = 3;
        StartCoroutine(Cooling());
    }

    IEnumerator Cooling()
    {
        Debug.Log("4");

        yield return new WaitForSeconds(1);
        cooling = (cooling - 1) % 3;
    }

    void Attack()
    {
        // to do
        // if player is withink enemy's attack scope, and player is not blocking, then player's health goes down
        // make sure that player's health only decreases once, either in this script or PlayerHurt.cs
        // should enemy's damage on the player > player's damage on the enemy?

        if (EnemyIsAttacking)
        {
            phurt.playerIsAttacked(ec.enemyDamage);
        }
    }
}

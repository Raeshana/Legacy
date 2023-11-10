using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController ec;
    public GameObject player;
    public Animator anim;

    private PlayerAttack pa;
    private PlayerBlock pb;
    private PlayerJump pj;
    private PlayerHurt phurt;

    public int enemyDamage;
    public bool EnemyIsAttacking = false;
    public int cooling;

    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponent<EnemyController>();
        pa = player.GetComponent<PlayerAttack>();
        pb = player.GetComponent<PlayerBlock>();
        pj = player.GetComponent<PlayerJump>();
        phurt = player.GetComponent<PlayerHurt>();
        cooling = 0;

        enemyDamage = 8; // slightly higher than playerDamage (=5)

    }

    // Update is called once per frame
    void Update()
    {
        

        if (EnemyShouldAttack() && cooling == 0
            && !ec.EnemyIsJumping && !ec.EnemyIsMoving && !ec.EnemyIsBlocking)
        {
            
            StartCoroutine(AttackRoutine());
        }
    }

    bool EnemyShouldAttack()
    {
        // if player is within attack scope, and player is not attacking, and is not blocking/about to end blocking
        return !pb.getIsBlocking() && !pj.getIsJumping() && !pa.getIsAttacking() && ec.horizontalDistanceBtw < ec.attackRange;
    }

    IEnumerator AttackRoutine()
    {
        anim.SetTrigger("EnemyCanAttack");
        anim.SetBool("EnemyIsAttacking", true);
        EnemyIsAttacking = true;
        Attack();
        EnemyIsAttacking = false;
        cooling = 2;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("EnemyIsAttacking", false);
        StartCoroutine(Cooling());
    }

    IEnumerator Cooling()
    {
        while (cooling != 0)
        {
            yield return new WaitForSeconds(100 * Time.deltaTime);
            cooling = (cooling - 1) % 1;
        }
    }

    void Attack()
    {
        // to do
        // if player is withink enemy's attack scope, and player is not blocking, then player's health goes down
        // make sure that player's health only decreases once, either in this script or PlayerHurt.cs
        // should enemy's damage on the player > player's damage on the enemy?
        phurt.playerIsAttacked(enemyDamage);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// possible resource: https://www.youtube.com/watch?v=AD4JIXQDw0s

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private EnemyHealth hp;
    private EnemyAttack ea;
    public Animator anim;

    public bool EnemyIsAlive = true;
    public bool EnemyIsJumping = false;
    public bool EnemyIsBlocking = false;

    GameObject player;
    private PlayerAttack pa;

    private float jumpForce; // should it be public? should enemy use the same parameters as player?
    public float enemyWidth;
    public float horizontalDistanceBtw;

    public float attackRange;

    public float hurtEnemyInARow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        hp = GetComponent<EnemyHealth>();
        ea = GetComponent<EnemyAttack>();

        sr.flipX = true; // assuming that the enemy is facing right by default (x>0),
                         // then it should be flipped as the game start to face left (facing the player)

        player = GameObject.FindGameObjectWithTag("Player");
        pa = player.GetComponent<PlayerAttack>();

        enemyWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        attackRange = enemyWidth / 2; // !! notice that this line is redundant in ec, but I can't find another way to calculate the aR as program starts
    }

    // Update is called once per frame

    bool EnemyShouldBlock()
    {
        int p_block = Random.Range(0, 2); //50% change that the enemy will block
        return horizontalDistanceBtw <= attackRange * 0.75 // if enemy is withink player's attack range
            && pa.getIsAttacking() && (p_block == 1); // and player is attacking
    }

    IEnumerator BlockRoutine()
    {
        anim.SetBool("EnemyIsBlocking", true);
        yield return new WaitForSeconds(0.2f);
        EnemyIsBlocking = false;
        anim.SetBool("EnemyIsBlocking", false);
    }

    void ClearEnemyHurtInRow()
    {
        if (horizontalDistanceBtw > attackRange)
        {
            // player & enemy is outside of each other's attackRange, so...
            hurtEnemyInARow = 0;
        }
    }

    void Update()
    {
        hurtEnemyInARow = hp.hurtEnemyInARow;
        if (EnemyIsAlive) {
            horizontalDistanceBtw = Mathf.Abs(player.transform.position.x - rb.position.x);
            ClearEnemyHurtInRow();

            if (EnemyShouldBlock() && !EnemyIsJumping && !ea.EnemyIsAttacking) // allowed to block while moving
            {
                EnemyIsBlocking = true;
                StartCoroutine(BlockRoutine());
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Ground"))
        //{ // if the obj that player is colliding with has the tag 'ground'
        //    EnemyIsJumping = false;
        //    anim.SetBool("EnemyIsJumping", false);
        //}
        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(FlashRoutine());
        }
    }

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        EnemyIsJumping = true;
    //        anim.SetBool("EnemyIsJumping", true);
    //    }
    //}

    private IEnumerator FlashRoutine() {
        sr.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}

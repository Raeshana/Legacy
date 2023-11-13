using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private EnemyController ec;
    private EnemyHealth eh;
    public GameObject player;
    private PlayerAttack pa;
    private PlayerMovement pm;
    public Animator anim;

    public float moveDirection;
    public float charactersOrientation;
    public float horizontalDistanceBtw;
    public float attackRange;
    public float hurtEnemyInARow;
    public float enemyWidth;
    public bool EnemyIsJumping;
    public bool EnemyIsBlocking;
    public bool EnemyIsMoving = false;

    private float EnemyMoveSpeed;
    public bool shouldChase = true;
    public bool shouldEscape = false;
    //public bool EnemyIsEscaping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ec = GetComponent<EnemyController>();
        eh = GetComponent<EnemyHealth>();
        pa = player.GetComponent<PlayerAttack>();
        pm = player.GetComponent<PlayerMovement>();
        
        enemyWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        attackRange = (enemyWidth) / 2;
        

        EnemyMoveSpeed = (float)(pm.moveSpeed * 0.5);
    }

    // Update is called once per frame
    void EnemyFlip(int escapeIndicator)
    {
        if (charactersOrientation * // if co > 0, E is on P's right
            escapeIndicator > 0f) // if i>0, is escaping, should escape further to the right; then md*i>0, then should not flip
        {
            sr.flipX = false; // assuming that the enemy is facing right by default (x>0)
        }
        else
        {
            sr.flipX = true;
        }
    }

    bool EnemyShouldMove()
    {
        float distance = Vector2.Distance(rb.position, player.transform.position);
        horizontalDistanceBtw = ec.horizontalDistanceBtw;
        shouldChase = (horizontalDistanceBtw >= attackRange * 0.75)
            && (distance >= attackRange * 0.75);
        shouldEscape = (horizontalDistanceBtw <= attackRange * 5) && (hurtEnemyInARow >= 2) && pa.getIsAttacking();
        //Debug.Log("should move?");
        //Debug.Log(shouldChase);
        //Debug.Log(horizontalDistanceBtw);
        //Debug.Log(distance);
        //Debug.Log(attackRange * 0.75);
        //Debug.Log(shouldEscape);
        return (shouldChase) || shouldEscape;
    }

    void Move()
    {
        //Debug.Log("--");
        //Debug.Log(Screen.width);
        //Debug.Log(enemyWidth);
        //Debug.Log(rb.position.x);
        //Debug.Log(player.transform.position.x);
        //Debug.Log("and");
        //Debug.Log(Screen.width - enemyWidth);
        //Debug.Log(rb.position.x + attackRange * 10);

        if (shouldEscape)
        {
            moveDirection = charactersOrientation; // if enemy is on player's right, co>0, should escape to right(+)
            rb.velocity = new Vector2(EnemyMoveSpeed * moveDirection, rb.velocity.y);
            EnemyFlip(1);
        }
        else
        {
            Debug.Assert(shouldChase);
            moveDirection = charactersOrientation * -1;
            Vector2 target = new Vector2(player.transform.position.x, rb.position.y); // moving towards the player
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, EnemyMoveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            EnemyFlip(-1);
        }
    }

    void Update()
    {
        EnemyIsJumping = ec.EnemyIsJumping;
        EnemyIsBlocking = ec.EnemyIsBlocking;
        charactersOrientation = rb.position.x - player.transform.position.x; // if enemy is on player's right, co > 0
        hurtEnemyInARow = eh.hurtEnemyInARow;
        if (EnemyShouldMove() && !EnemyIsJumping
                && !EnemyIsBlocking) // enemy should be allowed to move while attacking?
        {
            EnemyIsMoving = true;
            anim.SetBool("EnemyIsMoving", true);
            Move();
        }
        else
        {
            EnemyIsMoving = false;
            anim.SetBool("EnemyIsMoving", false);

        }
    }
}

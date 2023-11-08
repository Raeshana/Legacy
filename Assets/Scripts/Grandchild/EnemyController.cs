using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// possible resource: https://www.youtube.com/watch?v=AD4JIXQDw0s
// next step:
// 1. search for how to make a good combat enemy AI / gameplay strategies in street fighter
// 2. create an invisible gameObj with BoxCollision to detect whether player is in enemy's attack scope

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sr;

    public bool EnemyIsAlive = true;
    public bool EnemyIsJumping = false;
    public bool EnemyIsMoving = false;
    public bool EnemyIsAttacking = false;
    public bool EnemyIsBlocking = false;

    private float jumpForce; // should it be public? should enemy use the same parameters as player?
    private float moveSpeed;

    private float moveDirection;

    [SerializeField] ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true; // assuming that the enemy is facing right by default (x>0),
                         // then it should be flipped as the game start to face left (facing the player)

    }

    // Update is called once per frame

    bool EnemyShouldJump()
    {
        // to do
        return false;
    }

    bool EnemyShouldMove()
    {
        // to do
        return false;
    }

    bool EnemyShouldAttack()
    {
        // to do
        // if player is within attack scope, and player is not attacking, and is not blocking/about to end blocking
        return false;
    }

    bool EnemyShouldBlock()
    {
        // to do
        // if enemy is withink player's attack scope, and player is attacking
        return false;
    }

    void EnemyMove()
    {
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
        if (moveDirection < 0f)
        {
            sr.flipX = true; // assuming that the enemy is facing right by default (x>0)
        }
        else
        {
            sr.flipX = false;
        }
        dust.Play();
    }

    void EnemyAttack()
    {
        // to do
        // if player is withink enemy's attack scope, and player is not blocking, then player's health goes down
        // make sure that player's health only decreases once, either in this script or PlayerHurt.cs
    }

    void Update()
    {
        if (EnemyIsAlive) {
            if (EnemyShouldJump() && !EnemyIsMoving
                && !EnemyIsAttacking && EnemyIsBlocking)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            }

            if (EnemyShouldMove() && !EnemyIsJumping
                && !EnemyIsAttacking && EnemyIsBlocking)
            {
                EnemyIsMoving = true;
                EnemyMove();
            }
            else
            {
                EnemyIsMoving = false;
            }

            if (EnemyShouldAttack() && !EnemyIsJumping
                && !EnemyIsMoving && EnemyIsBlocking)
            {
                EnemyIsBlocking = true;
                EnemyAttack();
            }
            else
            {
                EnemyIsBlocking = false;
            }

            if (EnemyShouldBlock() && !EnemyIsJumping
                && !EnemyIsMoving && EnemyIsAttacking)
            {
                EnemyIsBlocking = true;
            }
            else
            {
                EnemyIsBlocking = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { // if the obj that player is colliding with has the tag 'ground'
            EnemyIsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            EnemyIsJumping = true;
        }
    }
}

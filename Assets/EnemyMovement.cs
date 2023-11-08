using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        return false;
    }

    bool EnemyShouldBlock()
    {
        // to do
        return false;
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
                rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
                if (moveDirection < 0f)
                {
                    sr.flipX = true; // assume that the enemy is facing right (x>0)
                }
                else
                {
                    sr.flipX = false;
                }
                dust.Play();
            }
            else
            {
                EnemyIsMoving = false;
            }

            if (EnemyShouldAttack() && !EnemyIsJumping
                && !EnemyIsMoving && EnemyIsBlocking)
            {
                EnemyIsBlocking = true;
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

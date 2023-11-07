using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] float moveSpeed;
    private float moveDirection;

    private PlayerAttack attack;
    private PlayerBlock block;

    private static bool isMoving;

    [SerializeField] ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        sr = GetComponent<SpriteRenderer> ();
        attack = GetComponent<PlayerAttack> ();
        block = GetComponent<PlayerBlock> ();

        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        moveDirection = Input.GetAxis("Horizontal");
        
        if (moveDirection != 0f && !attack.getIsAttacking() && !block.getIsBlocking())
        {
            rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
            if (moveDirection < 0f)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
            dust.Play();
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public bool getIsMoving()
    {
        return isMoving;
    }
}

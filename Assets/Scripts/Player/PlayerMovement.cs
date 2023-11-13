using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer sr;

    //[SerializeField] float moveSpeed;
    public float moveSpeed; 
    private float moveDirection;

    private PlayerAttack attack;
    private PlayerBlock block;
    private PlayerJump jump;

    private static bool isMoving;

    [SerializeField] ParticleSystem dust;

    private Animator anim;

    public GameObject enemy;
    private EnemyHealth eh;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        sr = GetComponent<SpriteRenderer> ();
        attack = GetComponent<PlayerAttack> ();
        block = GetComponent<PlayerBlock> ();
        jump = GetComponent<PlayerJump> ();
        anim = GetComponent<Animator> ();


        eh = enemy.GetComponent<EnemyHealth>();

        isMoving = false;
        anim.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
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
            eh.hurtEnemyInARow = 0;
            if (!jump.getIsJumping())
            {
                anim.SetBool("isWalking", true);
            }
            else{
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            isMoving = false;
            anim.SetBool("isWalking", false);
        }
    }

    public bool getIsMoving()
    {
        return isMoving;
    }
}

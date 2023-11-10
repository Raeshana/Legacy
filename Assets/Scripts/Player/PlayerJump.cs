using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] GameObject ground;
    private Collider2D groundCollider;

    [SerializeField] float jumpForce;

    private PlayerAttack attack;
    private PlayerBlock block;
    private PlayerMovement move;

    private static bool isJumping;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        groundCollider = ground.GetComponent<Collider2D>();
        attack = GetComponent<PlayerAttack> ();
        block = GetComponent<PlayerBlock> ();
        move = GetComponent<PlayerMovement> ();
        anim = GetComponent<Animator> ();

        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && rb.IsTouching(groundCollider) && !attack.getIsAttacking() && !block.getIsBlocking() && !move.getIsMoving())
        {
            isJumping = true;
            StartCoroutine(JumpRoutine());
        }

        if (!rb.IsTouching(groundCollider))
        {
            isJumping = true;
            anim.SetBool("isFalling", true);
        }
        else
        {
            isJumping = false;
            anim.SetBool("isFalling", false);
        }
    }

    IEnumerator JumpRoutine()
    {
        anim.SetTrigger("canJump");
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public bool getIsJumping()
    {
        return isJumping;
    }
}

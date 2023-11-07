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

    private static bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        groundCollider = ground.GetComponent<Collider2D>();
        attack = GetComponent<PlayerAttack> ();
        block = GetComponent<PlayerBlock> ();

        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && rb.IsTouching(groundCollider) && !attack.getIsAttacking() && !block.getIsBlocking())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
        else if (rb.IsTouching(groundCollider))
        {
            isJumping = false;
        }
    }

    public bool getIsJumping()
    {
        return isJumping;
    }
}

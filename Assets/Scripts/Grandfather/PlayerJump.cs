using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] GameObject ground;
    private Collider2D groundCollider;

    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        groundCollider = ground.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && rb.IsTouching(groundCollider))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

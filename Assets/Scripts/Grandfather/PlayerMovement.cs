using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    private float moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }
}

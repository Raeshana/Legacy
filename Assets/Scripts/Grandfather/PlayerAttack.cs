using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerJump jump;
    private PlayerMovement move;
    private PlayerBlock block;

    private static bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<PlayerJump> ();
        move = GetComponent<PlayerMovement> ();
        block = GetComponent<PlayerBlock> ();

        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {        
        if (!jump.getIsJumping() && !move.getIsMoving() && !block.getIsBlocking() && Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Attack");
            isAttacking = true;
        }
        else
        {
            isAttacking = false; // last frame of attack animation
        }
    }

    public bool getIsAttacking()
    {
        return isAttacking;
    }
}

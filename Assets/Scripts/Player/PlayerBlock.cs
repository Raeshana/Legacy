using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private PlayerJump jump;
    private PlayerMovement move;
    private PlayerAttack attack;

    private static bool isBlocking;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<PlayerJump> ();
        move = GetComponent<PlayerMovement> ();
        attack = GetComponent<PlayerAttack> ();
        anim = GetComponent<Animator> ();

        isBlocking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!jump.getIsJumping() && !move.getIsMoving() && !attack.getIsAttacking() && Input.GetButtonUp("Fire2"))
        {
            Debug.Log("Block");
            isBlocking = true;
            anim.SetTrigger("canBlock");
        }
        else
        {
            isBlocking = false;
        }
    }

    public bool getIsBlocking()
    {
        return isBlocking;
    }
}

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

    public GameObject enemy;
    private EnemyHealth eh;

    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<PlayerJump> ();
        move = GetComponent<PlayerMovement> ();
        attack = GetComponent<PlayerAttack> ();
        anim = GetComponent<Animator> ();

        isBlocking = false;

        eh = enemy.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jump.getIsJumping() && !move.getIsMoving() && !attack.getIsAttacking() && !attack.getIsPowerAttacking() && Input.GetButton("Fire2"))
        {
            isBlocking = true;
            eh.hurtEnemyInARow = 0;
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

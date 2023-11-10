using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// possible resource: https://www.youtube.com/watch?v=AD4JIXQDw0s
// next step:
// 1. search for how to make a good combat enemy AI / gameplay strategies in street fighter
// 2. separate the scripts to make them organized

public class EnemyController : MonoBehaviour
{
    public string sceneToLoad;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private EnemyHealth hp;
    private EnemyAttack ea;
    public Animator anim;


    public bool EnemyIsAlive = true;
    public bool EnemyIsJumping = false;
    public bool EnemyIsMoving = false;
    public bool EnemyIsBlocking = false;


    GameObject player;
    private PlayerMovement pm;
    private PlayerAttack pa;

    private float jumpForce; // should it be public? should enemy use the same parameters as player?
    private float EnemyMoveSpeed;
    public float moveDirection;
    private float EnemyWidth;
    public float horizontalDistanceBtw;

    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        hp = GetComponent<EnemyHealth>();
        ea = GetComponent<EnemyAttack>();

        sr.flipX = true; // assuming that the enemy is facing right by default (x>0),
                         // then it should be flipped as the game start to face left (facing the player)

        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        pa = player.GetComponent<PlayerAttack>();

        EnemyMoveSpeed = (float)(pm.moveSpeed * 0.5);
        EnemyWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        attackRange = EnemyWidth / 2;
    }

    // Update is called once per frame

    bool EnemyShouldMove()
    {
        float distance = Vector2.Distance(rb.position, player.transform.position);
        return (horizontalDistanceBtw >= attackRange * 0.75)
            && (distance >= attackRange * 0.75);
    }

    void EnemyMove()
    {
        EnemyFlip();
        Vector2 target = new Vector2(player.transform.position.x, rb.position.y); //always moving towards the player
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, EnemyMoveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    bool EnemyShouldBlock()
    {
        int p_block = Random.Range(0, 2); //50% change that the enemy will block
        return horizontalDistanceBtw <= attackRange * 0.75 // if enemy is withink player's attack range
            && pa.getIsAttacking() && (p_block == 1); // and player is attacking
    }

    IEnumerator BlockRoutine()
    {
        Debug.Log("blockRoutine");
        anim.SetBool("EnemyIsBlocking", true);
        yield return new WaitForSeconds(0.2f);
        EnemyIsBlocking = false;
        anim.SetBool("EnemyIsBlocking", false);
    }

    void EnemyFlip()
    {
        if (moveDirection > 0f) // md>0, E is on P's right, should flip
        {
            sr.flipX = true; // assuming that the enemy is facing right by default (x>0)
        }
        else 
        {
            sr.flipX = false;
        }
    }

    void Update()
    {
        if (EnemyIsAlive) {
            horizontalDistanceBtw = Mathf.Abs(player.transform.position.x - rb.position.x);
            moveDirection = rb.position.x - player.transform.position.x; // if enemy is on player's right, md > 0

            if (EnemyShouldMove() && !EnemyIsJumping
                && !EnemyIsBlocking) // enemy should be allowed to move while attacking?
            {
                EnemyIsMoving = true;
                anim.SetBool("EnemyIsMoving", true);
                EnemyMove();
            }
            else
            {
                EnemyIsMoving = false;
                anim.SetBool("EnemyIsMoving", false);

            }
           

            if (EnemyShouldBlock() && !EnemyIsJumping && !ea.EnemyIsAttacking) // allowed to block while moving
            {
                Debug.Log("is blocking");
                EnemyIsBlocking = true;
                StartCoroutine(BlockRoutine());
            }
            
        }
        else {
            PlayerPrefs.SetInt("Win", 1);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Ground"))
        //{ // if the obj that player is colliding with has the tag 'ground'
        //    EnemyIsJumping = false;
        //    anim.SetBool("EnemyIsJumping", false);
        //}
        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(FlashRoutine());
            //default damage is 5, maybe change it for normal attack and power attack?
            hp.EnemyIsAttacked(5);
        }
    }

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        EnemyIsJumping = true;
    //        anim.SetBool("EnemyIsJumping", true);
    //    }
    //}

    private IEnumerator FlashRoutine() {
        sr.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}

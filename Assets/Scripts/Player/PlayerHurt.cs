using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    public string sceneToLoad;
    private SpriteRenderer sr;
    private PlayerHealth health;
    private PlayerBlock block;
    private float moveDirection;

    public GameObject enemy;
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        health = GetComponent<PlayerHealth> ();
        block = GetComponent<PlayerBlock> ();
        enemyController = enemy.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health.getHealth() == 0)
        {
            PlayerPrefs.SetInt("Win", 0);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public bool PlayerIsFacingEnemy()
    {
        Debug.Log(enemyController);
        Debug.Log(enemyController.moveDirection >= 0);
        return (!sr.flipX && enemyController.moveDirection >= 0) // player facing right (doesn't flipped) && enemy is on player's right
            || (sr.flipX && enemyController.moveDirection <= 0); // player facing left (flipped) && enemy is on player's left
    }

    public void playerIsAttacked(int damage)
    {
        if (block.getIsBlocking() || !PlayerIsFacingEnemy()) // if player is blocking || enemy is not facing the player while attacking
        {
            return; // player won't get hurt
        }

        StartCoroutine(FlashRoutine());
        //default damage is 5, maybe change it for normal attack and power attack?
        Debug.Log(damage);
        health.TakeDamage(damage);
        if (health.getHealth() == 0)
        {
            PlayerPrefs.SetInt("Win", 0);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        StartCoroutine(FlashRoutine());
    //        //default damage is 5, maybe change it for normal attack and power attack?
    //        health.TakeDamage(5);
    //        if (health.getHealth() == 0) {
    //            PlayerPrefs.SetInt("Win", 0);
    //            SceneManager.LoadScene(sceneToLoad);
    //        }
    //    }
    //}

    private IEnumerator FlashRoutine()
    {
        Debug.Log("p flashroutine");
        sr.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}

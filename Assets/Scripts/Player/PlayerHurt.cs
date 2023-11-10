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

    GameObject enemy;
    private EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        health = GetComponent<PlayerHealth> ();
        block = GetComponent<PlayerBlock> ();
        enemyHealth = enemy.GetComponent<EnemyHealth>();
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

    public void playerIsAttacked(int damage)
    {
        if (block.getIsBlocking() || !enemyHealth.PlayerIsFacingEnemy()) // if player is blocking || enemy is not facing the player while attacking
        {
            return; // player won't get hurt
        }

        StartCoroutine(FlashRoutine());
        //default damage is 5, maybe change it for normal attack and power attack?
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
        sr.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}

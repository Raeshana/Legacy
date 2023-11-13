using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement pm;
    private EnemyController ec;
    private EnemyMove em;
    private bool EnemyIsBlocking;
    private bool EnemyIsAlive;

    public int health; // will be changed as enemy gets hurt
    public Slider healthBar;
    public string sceneToLoad;
    private int originalHealth; // to store the original health
    public int hurtEnemyInARow; // the player has successfully attacked the enemy # times in a row
    
    //private bool EnemyIsEnraged;

    // Start is called before the first frame update
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        ec = GetComponent<EnemyController>();
        em = GetComponent<EnemyMove>();
        EnemyIsAlive = ec.EnemyIsAlive;
        EnemyIsBlocking = ec.EnemyIsBlocking;
        originalHealth = health;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlayerIsFacingEnemy()
    {
        return (pm.sr.flipX && !em.sr.flipX)
            || (!pm.sr.flipX && em.sr.flipX); // one of the characters must be flipped
    }


    public void EnemyIsAttacked(int damage)
    {
        if (EnemyIsBlocking || !PlayerIsFacingEnemy()) // if enemy is blocking || player is not facing the enemy while attacking
        {
            //Debug.Log(EnemyIsBlocking);
            //Debug.Log(!PlayerIsFacingEnemy());
            hurtEnemyInARow = 0;
            return; // enemy won't get hurt
        }

        hurtEnemyInARow += 1;
        health -= damage;
        UpdateHealthBar();

        //if (health < originalHealth * 0.5) // implement this if have time
        //{
        //    EnemyIsEnraged = true;
        //}

        if (health <= 0)
        {
            EnemyIsAlive = false;
            PlayerPrefs.SetInt("Win", 1);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void UpdateHealthBar() {
        if (health < 0) {
            healthBar.value = 0 / originalHealth;
        } else {
            healthBar.value = (float)health / originalHealth;
        }
    }
}

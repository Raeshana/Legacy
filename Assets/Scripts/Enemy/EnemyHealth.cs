using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health; // will be changed as enemy gets hurt
    public Slider healthBar;
    private int originalHealth; // to store the original health

    GameObject player;
    private PlayerMovement pm;
    private EnemyController ec;
    private bool EnemyIsBlocking;
    private bool EnemyIsAlive;
    //private bool EnemyIsEnraged;

    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponent<EnemyController>();
        pm = player.GetComponent<PlayerMovement>();
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

        return (!pm.sr.flipX && ec.moveDirection >= 0) // player facing right (doesn't flipped) && enemy is on player's right
            || (pm.sr.flipX && ec.moveDirection <= 0); // player facing left (flipped) && enemy is on player's left
    }

    public void EnemyIsAttacked(int damage)
    {
        if (EnemyIsBlocking || !PlayerIsFacingEnemy()) // if enemy is blocking || player is not facing the enemy while attacking
        {
            return; // enemy won't get hurt
        }

        health -= damage;
        health = Mathf.Clamp(health, 0, originalHealth); // Ensure health doesn't go below 0
        UpdateHealthBar();

        //if (health < originalHealth * 0.5) // implement this if have time
        //{
        //    EnemyIsEnraged = true;
        //}

        if (health <= 0)
        {
            EnemyIsAlive = false;
        }
    }

    void UpdateHealthBar() {
        healthBar.value = (float)health / originalHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health; // will be changed as enemy gets hurt
    public Slider healthBar;
    private int originalHealth; // to store the original health
    
    private EnemyController controller;
    private bool EnemyIsBlocking;
    private bool EnemyIsAlive;
    //private bool EnemyIsEnraged;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EnemyController>();
        EnemyIsAlive = controller.EnemyIsAlive;
        EnemyIsBlocking = controller.EnemyIsBlocking;
        originalHealth = health;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyIsAttacked(int damage)
    {
        if (EnemyIsBlocking) // if is blocking, won't get hurt
        {
            return;
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

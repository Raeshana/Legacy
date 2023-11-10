using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health; // will be changed as enemy gets hurt
    private int originalHealth; // to store the original health
    
    private EnemyController controller;
    private bool EnemyIsBlocking;
    private bool EnemyIsAlive;
    private bool EnemyIsEnraged;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EnemyController>();
        EnemyIsAlive = controller.EnemyIsAlive;
        EnemyIsBlocking = controller.EnemyIsBlocking;
        originalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyIsAttacked(int damage)
    {
        if (EnemyIsBlocking) // if is blocking, won't get hurt
        {
            return;
        }

        health -= damage;

        if (health < originalHealth * 0.5)
        {
            EnemyIsEnraged = true;
        }

        if (health < 0)
        {
            EnemyIsAlive = false;
        }
    }
}

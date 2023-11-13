using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    private PlayerHurt phurt;

    public bool EnemyIsAttacking = false;
    public bool EnemyIsPowerAttacking = false;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        phurt = player.GetComponent<PlayerHurt>();
        count = 1; // every 1 power attack for 4 normal attacks.
                   // Start at 1, can be 1, 2, 3, 4, 0
                   // Perform a power attack when count = 0.
    }

    public void IncrementCount()
    {
        count = (count + 1) % 5;
        //Debug.Log(count);
    }

    void Attack(int damage)
    {
        // enemyDamage = 4, enemyPowerDamage = 6;
        // to modify this, go to enemy's animation -> EnemyBasicAttack or EnemyPowerAttack -> change the input of the event when calling this function
        phurt.PlayerIsAttacked(damage);
    }

    // Update is called once per frame
    void Update()
    {
        // attack is determined and called in enemy's animation
    } 
}

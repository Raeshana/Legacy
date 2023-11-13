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
    public SpriteRenderer sr;
    private EnemyMove em;
    private bool EnemyIsBlocking;

    public int health; // will be changed as enemy gets hurt
    public Slider healthBar;
    public string sceneToLoad;
    private int originalHealth; // to store the original health
    public int hurtEnemyInARow; // the player has successfully attacked the enemy # times in a row
    
    // Start is called before the first frame update
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        ec = GetComponent<EnemyController>();
        em = GetComponent<EnemyMove>();
        EnemyIsBlocking = ec.EnemyIsBlocking;
        originalHealth = health;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool EnemyIsInFrontOfPlayer()
    {
        return (pm.sr.flipX && em.charactersOrientation <= 0) // p facing left & e on p left
            || (!pm.sr.flipX && em.charactersOrientation >= 0); // p facing right & e on p right
    }


    public void EnemyIsAttacked(int damage)
    {
        if (EnemyIsBlocking || !EnemyIsInFrontOfPlayer())
        {
            //Debug.Log("blocked damage");
            hurtEnemyInARow = 0; // ways to clear the hurtEnemyInARow:
                                 // 1. e successifully blocks an attack (in EnemyHealth.cs)
                                 // 2. e has escaped so that his far enough from p (in EnemyController.cs)
                                 // 3. p performs an interruptive action (block, jump, move) (in the three player scripts)
            return; // enemy won't get hurt
        }

        //Debug.Log("Ouch. Said the Grandpa.");
        hurtEnemyInARow += 1;
        StartCoroutine(FlashRoutine());
        health -= damage;
        UpdateHealthBar();

        if (health <= 0)
        {
            ec.EnemyIsAlive = false;
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

    private IEnumerator FlashRoutine()
    {
        sr.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}

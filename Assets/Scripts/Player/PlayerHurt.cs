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

    public GameObject enemy;
    private EnemyMove em;
    private EnemyHealth eh;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        health = GetComponent<PlayerHealth> ();
        block = GetComponent<PlayerBlock> ();
        em = enemy.GetComponent<EnemyMove>();
        eh = enemy.GetComponent<EnemyHealth>();
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

    public bool PlayerIsInFrontOfEnemy()
    {
        return (em.sr.flipX && em.charactersOrientation >= 0) // e facing left & e on p right
            || (!em.sr.flipX && em.charactersOrientation <= 0); // e facing right & e on p left
    }

    public void PlayerIsAttacked(int damage)
    {
        if (block.getIsBlocking() || !PlayerIsInFrontOfEnemy())
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

    private IEnumerator FlashRoutine()
    {
        sr.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}

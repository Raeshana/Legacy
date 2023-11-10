using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private SpriteRenderer sr;
    private PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer> ();
        health = GetComponent<PlayerHealth> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemySword")
        {
            StartCoroutine(FlashRoutine());
            //default damage is 5, maybe change it for normal attack and power attack?
            health.TakeDamage(5);
        }
    }

    private IEnumerator FlashRoutine()
    {
        sr.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}

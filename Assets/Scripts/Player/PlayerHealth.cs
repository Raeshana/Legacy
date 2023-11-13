using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Slider healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    private void Start() {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0
        UpdateHealthBar();
    }

    public int getHealth() {
        return currentHealth;
    }

    private void UpdateHealthBar() {
        healthBar.value = (float)currentHealth / maxHealth;
    }

    
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    Canvas canvas = null;

    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        canvas = null;
        canvas = GameObject.FindGameObjectWithTag("Game").GetComponent<Canvas>();
        canvas.enabled = false;
        canvas = GameObject.FindGameObjectWithTag("Dead").GetComponent<Canvas>();
        canvas.enabled = true;
    }
}
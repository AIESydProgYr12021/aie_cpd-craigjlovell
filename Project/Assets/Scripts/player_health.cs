using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GameOver");
    }
}
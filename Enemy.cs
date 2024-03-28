using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth, currentHealth;
    public HealthBar healthBar;

    public SpawnManager spawnManager;

    void Update()
    {
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        EnemyDeath();
        
    }


    void EnemyDeath()
    {
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);

            spawnManager.enemyCount += 1;
            

        }
    }
}

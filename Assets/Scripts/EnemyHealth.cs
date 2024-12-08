using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Initialize health
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took damage: " + damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // Remove enemy from the scene
    }
}

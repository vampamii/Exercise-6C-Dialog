using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Initialize health
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        GoToEndMenu();
    }
    void GoToEndMenu()
    
        { 
            SceneManager.LoadScene("EndMenu");
        }
    }


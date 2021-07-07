using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 10f;

    void Awake()
    {
        playerHealth = FindObectOfType<playerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.currentHealth = playerHealth.currentHealth + healthBonus;
        }

        if (playerHealth.currentHealth = playerHealth.maxHealth)
        {
            Destroy(gameObject);
        }
    }
}

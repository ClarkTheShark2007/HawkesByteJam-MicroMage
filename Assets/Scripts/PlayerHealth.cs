using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)  
    {
        currentHealth -= damage;
        OnPlayerDamaged?.Invoke();
    }
}

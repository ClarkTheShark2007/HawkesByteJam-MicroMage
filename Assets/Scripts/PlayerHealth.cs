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

    private Animator anim;

    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        OnPlayerDamaged?.Invoke();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)  
    {
        currentHealth -= damage;
        OnPlayerDamaged?.Invoke();

        if (currentHealth <= 0) 
        {
            anim.SetTrigger("Gameover");
            GetComponent<PlayerMovement>().enabled = false;
            aud.Play();
            OnPlayerDeath?.Invoke();
        }
    }
}

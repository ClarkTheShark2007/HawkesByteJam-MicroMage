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

    private BoxCollider2D hitbox;

    public AudioSource death;
    public AudioSource hit;

    public AudioSource main;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        OnPlayerDamaged?.Invoke();
        anim = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider2D>();

    }

    public void TakeDamage(int damage)  
    {
        currentHealth -= damage;
        OnPlayerDamaged?.Invoke();
        hit.Play();

        if (currentHealth <= 0) 
        {
            anim.SetTrigger("Gameover");
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            death.Play();
            hit.Stop();
            hitbox.enabled = false;
            OnPlayerDeath?.Invoke();
        }
    }
}

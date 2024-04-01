/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EyeBossHealth : EnenmyHealth
{

    public static event Action OnBossDamaged;
    public static event Action OnBossDeath;

    public GameObject blueEnemy1;
    public GameObject blueEnemy2;

    public GameObject redEnemy1;
    public GameObject redEnemy2;

    public GameObject Boss;

    private Animator anim;

    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        OnBossDamaged?.Invoke();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    public void Death(int damage)  
    {
        if (currentHealth <= 0) 
        {
            aud.Play();
            Boss.GetComponent<SpriteRenderer>().enabled = false;
            Boss.GetComponent<Collider2D>().enabled = false;
            blueEnemy1.SetActive(true);
            Destroy(Boss, 1f);
            OnBossDeath?.Invoke();
        }
    }

    public void TakeDamage(int damage)  
    {
        currentHealth -= damage;

        if (currentHealth <= 0) 
        {
            aud.Play();
            Boss.GetComponent<SpriteRenderer>().enabled = false;
            Boss.GetComponent<Collider2D>().enabled = false;
            blueEnemy1.SetActive(true);
            Destroy(Boss, 1f);
            OnBossDeath?.Invoke();
        }
    }
}
*/

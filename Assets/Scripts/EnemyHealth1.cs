using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnenmyHealth : MonoBehaviour
{

    public static event Action OnEnemyDamaged;
    public static event Action OnEnemyDeath;

    public int maxHealth;
    public int currentHealth;

    public GameObject[] itemDrops;
    private Animator anim;

    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        OnEnemyDamaged?.Invoke();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)  
    {
        currentHealth -= damage;
        OnEnemyDamaged?.Invoke();

        if (currentHealth <= 0) 
        {
            die();
        }
    }
    private void die()
    {
        aud.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        OnEnemyDeath?.Invoke();
        dropItem();
        Destroy(gameObject, 1f);
        
    }
    private void dropItem()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}

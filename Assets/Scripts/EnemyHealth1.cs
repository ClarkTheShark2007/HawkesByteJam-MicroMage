using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnenmyHealth : MonoBehaviour
{

    public static event Action OnEnemyDamaged;
    public static event Action OnEnemyDeath;

    [SerializeField]private int maxHealth;
    [SerializeField]private int currentHealth;

    [SerializeField]private int dropChance;
    [SerializeField]private GameObject[] itemDrops;

    [SerializeField]private Animator anim;

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
        if(UnityEngine.Random.Range(0, dropChance) == 1)
        {
            Instantiate(itemDrops[0], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        else
        {
             Instantiate(itemDrops[1], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}

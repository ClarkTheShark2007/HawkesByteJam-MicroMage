using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class EnenmyHealth : MonoBehaviour
{

    public static event Action OnEnemyDamaged;
    public static event Action OnEnemyDeath;

    [SerializeField]private int maxHealth = 10;
    [SerializeField]private int currentHealth = 10;

    [SerializeField]private int spellDropChance = 101;
    [SerializeField]private int upgradeDropChance = 11;
    [SerializeField]private int heartDropChance = 6;
    [SerializeField]private GameObject[] itemDrops;

    [SerializeField]private Animator anim;
    
    private Boolean backup = false;
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
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        OnEnemyDeath?.Invoke();
        dropItem();
        Destroy(gameObject, 1f);
        
    }
    private void dropItem()
    {
        if(!backup)
        {
            if(UnityEngine.Random.Range(0, spellDropChance) == 1)
                {
                    Instantiate(itemDrops[0], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    backup = true;
                }
            else
                {
                if(UnityEngine.Random.Range(0, upgradeDropChance) == 1)
                    {
                        Instantiate(itemDrops[1], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                        backup = true;
                    }
                else
                    {
                    if(UnityEngine.Random.Range(0, heartDropChance) == 1)
                        {
                            Instantiate(itemDrops[2], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                            backup = true;
                        }
                    }
                }
        }
    }
}

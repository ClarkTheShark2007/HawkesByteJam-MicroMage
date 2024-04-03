using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    private PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerHealth>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            playerHealth.Heal(1);
            Destroy(gameObject);
        }
    }
}

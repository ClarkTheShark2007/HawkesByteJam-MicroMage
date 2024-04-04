using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDrop : MonoBehaviour
{
    private Spell[] spellDrops;
    private InventoryManager inventoryManager;
    private int RandomSpell;
    private PowerUpManager powerUpManager;
    // Start is called before the first frame update
    void Start()
    {
        Spell dropedSpell;
        spellDrops = new Spell[3];
        for(int i = 0; i < 3; i++)
        {   
            dropedSpell = GameObject.FindGameObjectWithTag("Player")?.GetComponents<Spell>()[i];
            spellDrops[i] = dropedSpell;
        }
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
        powerUpManager = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PowerUpManager>(); 
        RandomSpell = UnityEngine.Random.Range(0, spellDrops.Length);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {  
        RandomSpell = UnityEngine.Random.Range(0, spellDrops.Length);
        if(other.gameObject.tag == "Player") 
        {
            UnityEngine.Random.Range(0, spellDrops.Length);
            powerUpManager.startPowerUp(spellDrops[RandomSpell], spellDrops[RandomSpell].slot);
            Destroy(gameObject);
        }
    }
}

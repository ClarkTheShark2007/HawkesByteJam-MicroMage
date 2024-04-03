using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDrop : MonoBehaviour
{
    private Spell[] spellDrops;
    private InventoryManager inventoryManager;
    private int RandomSpell;
    // Start is called before the first frame update
    void Start()
    {
        Spell dropedSpell;
        spellDrops = new Spell[4];
        for(int i = 0; i < 4; i++)
        {   
            dropedSpell = GameObject.FindGameObjectWithTag("Player")?.GetComponents<Spell>()[i];
            spellDrops[i] = dropedSpell;
        }
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
        RandomSpell = UnityEngine.Random.Range(0, spellDrops.Length);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {  
        RandomSpell = UnityEngine.Random.Range(0, spellDrops.Length);
        if(other.gameObject.tag == "Player") 
        {
            
            UnityEngine.Random.Range(0, spellDrops.Length);
            inventoryManager.setSpellAtIndex(spellDrops[RandomSpell], spellDrops[RandomSpell].slot);
            Destroy(gameObject, 1f);
        }
    }
}

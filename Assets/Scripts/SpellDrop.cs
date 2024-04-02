using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDrop : MonoBehaviour
{
    [SerializeField] private Spell[] spellDrops;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        Spell circleBlast;
        circleBlast = GameObject.FindGameObjectWithTag("Player")?.GetComponents<Spell>()[2];
        spellDrops[0] = circleBlast;
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            inventoryManager.setSpellAtIndex(spellDrops[0], 0);
            Destroy(gameObject, 1f);
        }
    }
}

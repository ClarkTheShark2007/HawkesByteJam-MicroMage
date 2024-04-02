using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDrop : MonoBehaviour
{
    private InventoryManager inventoryManager;
    
    // Start is called before the first frame update
    void Start()
    {
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
            for(int i = 0; i != 2; i++)
            {
                inventoryManager.getSpellAtIndex(i).upgradeSpell();
            }
            Destroy(gameObject);
        }
    }
}

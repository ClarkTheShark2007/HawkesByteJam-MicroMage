using UnityEngine;

public class BouncyCollisionHandeler : MonoBehaviour
{
    public int spellIndex;
    private InventoryManager inventoryManager;
    private int damageAmount;
    void Awake()
    {
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
        damageAmount = inventoryManager.getSpellAtIndex(spellIndex).damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnenmyHealth enemyHealth = other.GetComponent<EnenmyHealth>(); // Assuming your enemy has the EnenmyHealth script attached

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount);
        }
    }
}
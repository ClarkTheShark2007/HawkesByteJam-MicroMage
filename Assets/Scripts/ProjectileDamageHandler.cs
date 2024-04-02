using UnityEngine;

public class ProjectileDamageHandler : MonoBehaviour
{
    [SerializeField] private int spellIndex;
    private InventoryManager inventoryManager;
    private int damageAmount;
    void Start()
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
            Destroy(gameObject); // Destroy the projectile on collision with the enemy
        }
    }
}

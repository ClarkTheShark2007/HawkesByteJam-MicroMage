using UnityEngine;
using UnityEditor;

public class FireworkCollisonHandler : MonoBehaviour
{
    public int spellIndex;
    private InventoryManager inventoryManager;
    private int damageAmount = 1;
    private int numProjectiles = 5;
    private int circleRadius = 1;
    public GameObject projectilePrefab;
    private int projectileSpeed = 5;
    private float projectileDuration = 0.5f;

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
            Burst();
            enemyHealth.TakeDamage(1);
            Destroy(gameObject);
        }
        else
        {
            if(!other.gameObject.CompareTag("Weapon"))
            {
                Burst();
                Destroy(gameObject); // Destroy the projectile when it collides with another object
            }
        }
    }

    private void Burst()
    {
            Vector3 burstPosition = transform.position;

            // Calculate the spawn position along a circle around the player
            float angleIncrement = 360f / numProjectiles; // Angle between each projectile
            float angle = 0f;

            for (int i = 0; i < numProjectiles; i++)
            {
                float offsetX = Mathf.Cos(angle * Mathf.Deg2Rad) * circleRadius;
                float offsetY = Mathf.Sin(angle * Mathf.Deg2Rad) * circleRadius;

                Vector3 spawnPosition = burstPosition + new Vector3(offsetX, offsetY, 0f);

                GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                projectile.AddComponent<ProjectileCollisionHandler>();
                projectile.GetComponent<ProjectileCollisionHandler>().spellIndex = spellIndex;
                
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                Vector3 velocity = (spawnPosition - burstPosition).normalized * projectileSpeed;
                rb.velocity = Quaternion.Euler(0f, 0f, -90f) * velocity; // Rotate velocity for curve effect

                Destroy(projectile, projectileDuration); // Destroy the projectile after the specified duration

                angle += angleIncrement; // Move to the next angle for the next projectile
            }
    }
}
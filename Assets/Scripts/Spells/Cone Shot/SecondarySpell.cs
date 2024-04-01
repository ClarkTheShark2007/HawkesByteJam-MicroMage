using UnityEngine;

public class SecondarySpell : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int numProjectiles = 5; // Number of projectiles to fire
    public float projectileSpeed = 5f;
    public float cooldownTime = 3f; // Cooldown time in seconds
    public float projectileDuration = 2f; // Duration of the projectile in seconds
    public float spreadAngle = 30f; // Spread angle for the projectiles
    public float spawnOffset = 1f; // Offset distance from the player
    
    public float lastFireTime; // Time when the spell was last fired (public for demonstration purposes)

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= lastFireTime + cooldownTime) // Left mouse button clicked and cooldown is over
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 playerPosition = transform.position;
            Vector3 direction = (mousePosition - playerPosition).normalized;

            // Calculate the spawn position with the offset in the direction of the mouse cursor
            Vector3 spawnPosition = playerPosition + direction * spawnOffset;

            // Calculate the angle between projectiles based on the spread angle
            float angleIncrement = spreadAngle / (numProjectiles - 1);

            for (int i = 0; i < numProjectiles; i++)
            {
                float angle = -spreadAngle / 2f + i * angleIncrement; // Start from the negative half of spread angle
                Vector3 projectileDirection = Quaternion.Euler(0f, 0f, angle) * direction; // Rotate direction by angle

                GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                projectile.AddComponent<ProjectileCollisionHandler>();

                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.velocity = projectileDirection * projectileSpeed; 

                Destroy(projectile, projectileDuration); // Destroy the projectile after the specified duration
            }

            lastFireTime = Time.time; // Update last fire time
        }
    }
}

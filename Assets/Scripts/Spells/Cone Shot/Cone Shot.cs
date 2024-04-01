using UnityEngine;

public class ConeShot : Spell
{
    private void Update()
    {
        if (casting && Time.time >= lastFireTime + cooldownTime) // Left mouse button clicked and cooldown is over
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
            casting = false;
            lastFireTime = Time.time; // Update last fire time
        }
    }
}

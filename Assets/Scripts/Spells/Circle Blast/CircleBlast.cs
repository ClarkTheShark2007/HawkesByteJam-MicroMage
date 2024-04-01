using UnityEngine;

public class CircleBlast : Spell
{
    private void Update()
    {
        if (casting && Time.time >= lastFireTime + cooldownTime) // Left mouse button clicked and cooldown is over
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 playerPosition = transform.position;
            Vector3 direction = (mousePosition - playerPosition).normalized;

            // Calculate the spawn position along a circle around the player
            float angleIncrement = 360f / numProjectiles; // Angle between each projectile
            float angle = 0f;

            for (int i = 0; i < numProjectiles; i++)
            {
                float offsetX = Mathf.Cos(angle * Mathf.Deg2Rad) * circleRadius;
                float offsetY = Mathf.Sin(angle * Mathf.Deg2Rad) * circleRadius;

                Vector3 spawnPosition = playerPosition + new Vector3(offsetX, offsetY, 0f);

                GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                projectile.AddComponent<ProjectileCollisionHandler>();

                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                Vector3 velocity = (spawnPosition - playerPosition).normalized * projectileSpeed;
                rb.velocity = Quaternion.Euler(0f, 0f, -90f) * velocity; // Rotate velocity for curve effect

                Destroy(projectile, projectileDuration); // Destroy the projectile after the specified duration

                angle += angleIncrement; // Move to the next angle for the next projectile
            }
            casting = false;
            lastFireTime = Time.time; // Update last fire time
        }
    }
}

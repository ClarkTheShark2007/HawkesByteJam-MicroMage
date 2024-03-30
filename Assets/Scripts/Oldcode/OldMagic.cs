/*using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public ProjectileBaseSO projectileSettings;

    private float lastFireTime; // Time when the spell was last fired

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastFireTime + projectileSettings.cooldownTime) // Left mouse button clicked and cooldown is over
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 playerPosition = transform.position;
            Vector3 direction = (mousePosition - playerPosition).normalized;

            // Calculate the spawn position with the offset in the direction of the mouse cursor
            Vector3 spawnPosition = playerPosition + direction * projectileSettings.spawnOffset;

            GameObject projectile = Instantiate(projectileSettings.projectilePrefab, spawnPosition, Quaternion.identity);
            projectile.AddComponent<ProjectileCollisionHandler>();

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSettings.projectileSpeed;

            Destroy(projectile, projectileSettings.projectileDuration); // Destroy the projectile after the specified duration

            lastFireTime = Time.time; // Update last fire time
        }
    }
}
*/
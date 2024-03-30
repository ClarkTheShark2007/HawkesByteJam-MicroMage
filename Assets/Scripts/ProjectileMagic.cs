using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float cooldownTime = 3f; // Cooldown time in seconds
    public float projectileDuration = 20f; // Duration of the projectile in seconds
    public float spawnOffset = 1f; // Offset distance from the player

    private float lastFireTime; // Time when the spell was last fired

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastFireTime + cooldownTime) // Left mouse button clicked and cooldown is over
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 playerPosition = transform.position;
            Vector3 direction = (mousePosition - playerPosition).normalized;

            // Calculate the spawn position with the offset in the direction of the mouse cursor
            Vector3 spawnPosition = playerPosition + direction * spawnOffset;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            projectile.AddComponent<ProjectileCollisionHandler>();

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;

            Destroy(projectile, projectileDuration); // Destroy the projectile after the specified duration

            lastFireTime = Time.time; // Update last fire time
        }
    }
}

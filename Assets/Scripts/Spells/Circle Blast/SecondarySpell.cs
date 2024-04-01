/*using UnityEngine;

public class SecondarySpell : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int numProjectiles = 5; // Number of projectiles to fire
    public float projectileSpeed = 5f;
    public float cooldownTime = 3f; // Cooldown time in seconds
    public float projectileDuration = 2f; // Duration of the projectile in seconds
    public float circleRadius = 1.5f; // Radius of the circle path
    public float lastFireTime; // Time when the spell was last fired 

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= lastFireTime + cooldownTime) // Left mouse button clicked and cooldown is over
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

            lastFireTime = Time.time; // Update last fire time
        }
    }
}*/

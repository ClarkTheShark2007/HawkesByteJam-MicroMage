using UnityEngine;

public class SecondarySpell : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public float cooldownTime = 3f; // Cooldown time in seconds
    public float projectileDuration = 2f; // Duration of the projectile in seconds
    public float spawnOffset = 1f; // Offset distance from the player
    public float forceMagnitude = 10f; // Magnitude of the force applied to the projectile

    public float lastFireTime; // Time when the spell was last fired

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= lastFireTime + cooldownTime) // Right mouse button clicked and cooldown is over
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
            rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse); // Apply force to the projectile

            // Calculate the rotation angle based on the direction and add 90 degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Destroy(projectile, projectileDuration); // Destroy the projectile after the specified duration

            lastFireTime = Time.time; // Update last fire time
        }
    }
}

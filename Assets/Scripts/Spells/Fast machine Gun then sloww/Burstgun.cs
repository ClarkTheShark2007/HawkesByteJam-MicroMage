using System.Collections;
using UnityEngine;

public class BurstSpell : Spell
{
    private int burstCount = 0; // Counter for burst projectiles fired

    public void Update()
    {
        if (casting)
        {
            StartBurst();
        }
    }

    private void StartBurst()
    {
        lastFireTime = Time.time;
        StartCoroutine(FireBurstWithDelay());
    }

    IEnumerator FireBurstWithDelay()
    {
        for (int i = 0; i < numProjectiles; i++)
        {
            // Fire projectile
            FireProjectile();

            // Wait for the burst delay
            yield return new WaitForSeconds(burstDelay);
        }

        // Reset casting flag after burst is complete
        casting = false;
    }

    private void FireProjectile()
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

            // Calculate the rotation angle based on the direction and add 90 degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Destroy(projectile, projectileDuration); // Destroy the projectile after the specified duration
            casting = false;
    }
}

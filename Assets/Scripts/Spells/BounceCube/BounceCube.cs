using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCube : Spell
{
    private void Update()
    {
        if (casting) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 playerPosition = transform.position;
            Vector3 direction = (mousePosition - playerPosition).normalized;

            // Calculate the spawn position with the offset in the direction of the mouse cursor
            Vector3 spawnPosition = playerPosition + direction * spawnOffset;

            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            projectile.AddComponent<BouncyCollisionHandeler>();

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed; 

            // Calculate the rotation angle based on the direction and add 90 degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Destroy(projectile, projectileDuration); // Destroy the projectile after the specified duration
            casting = false;
            lastFireTime = Time.time; // Update last fire time
        }
    }
    
}

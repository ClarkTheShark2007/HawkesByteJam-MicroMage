using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject); // Destroy the projectile when it collides with another object
    }
}

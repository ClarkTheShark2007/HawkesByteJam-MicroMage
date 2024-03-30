using UnityEngine;

public class ProjectileDamageHandler : MonoBehaviour
{
    public int damageAmount = 1; // Damage amount caused by the projectile

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnenmyHealth enemyHealth = other.GetComponent<EnenmyHealth>(); // Assuming your enemy has the EnenmyHealth script attached

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount);
            Destroy(gameObject); // Destroy the projectile on collision with the enemy
        }
    }
}

using UnityEngine;

public class Spell : MonoBehaviour
{

    public void castSpell()
    {
        this.casting = true;

    }

    public GameObject projectilePrefab;
    protected bool casting = false;
    public int numProjectiles = 5; // Number of projectiles to fire
    public float projectileSpeed = 5f;
    public float cooldownTime = 3f; // Cooldown time in seconds
    public float projectileDuration = 2f; // Duration of the projectile in seconds
    public float spreadAngle = 30f; // Spread angle for the projectiles
    public float spawnOffset = 1f; // Offset distance from the player
    public float forceMagnitude = 10f; // Magnitude of the force applied to the projectile
    public float circleRadius = 1.5f; // Radius of the circle path
    public float lastFireTime; // Time when the spell was last fired 

}
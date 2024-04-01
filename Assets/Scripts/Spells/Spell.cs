using UnityEngine;

public class Spell : MonoBehaviour
{

    public void castSpell()
    {
        if(Time.time >= lastFireTime + cooldownTime)
        {
        this.casting = true;
        }
    }

    public GameObject projectilePrefab;
    protected bool casting = false;
    protected int numProjectiles = 5; // Number of projectiles to fire
    protected float projectileSpeed = 5f;
    public float cooldownTime = 3f; // Cooldown time in seconds
    protected float projectileDuration = 2f; // Duration of the projectile in seconds
    protected float spreadAngle = 30f; // Spread angle for the projectiles
    protected float spawnOffset = 1f; // Offset distance from the player
    protected float forceMagnitude = 10f; // Magnitude of the force applied to the projectile
    protected float circleRadius = 1.5f; // Radius of the circle path
    public float lastFireTime; // Time when the spell was last fired 

}
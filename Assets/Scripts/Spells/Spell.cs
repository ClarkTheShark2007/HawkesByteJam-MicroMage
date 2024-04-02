using UnityEngine;

public class Spell : MonoBehaviour
{

    private static readonly float UPGRADE_PERCENT = 0.1f;
    
    public void castSpell()
    {
        if(Time.time >= lastFireTime + cooldownTime)
        {
            this.casting = true;
        }
    }

    public void upgradeSpell()
    {
        this.projectileSpeed = this.projectileSpeed*(1+UPGRADE_PERCENT);
        this.cooldownTime = this.cooldownTime/(1-UPGRADE_PERCENT);
        this.damageAmount = this.damageAmount+1;
    }


    public GameObject projectilePrefab;
    protected bool casting = false;
    protected int numProjectiles = 5; // Number of projectiles to fire
    [SerializeField] protected float projectileSpeed = 5f;
    [SerializeField] public float cooldownTime = 3f; // Cooldown time in seconds
    protected float projectileDuration = 2f; // Duration of the projectile in seconds
    protected float spreadAngle = 30f; // Spread angle for the projectiles
    protected float spawnOffset = 1f; // Offset distance from the player
    protected float forceMagnitude = 10f; // Magnitude of the force applied to the projectile
    protected float circleRadius = 1.5f; // Radius of the circle path
    [System.NonSerialized]public float lastFireTime; // Time when the spell was last fired 
    public int damageAmount = 1;
}
using UnityEngine;
using TMPro;

public class PrimaryCooldownDisplay : MonoBehaviour
{
    public TextMeshProUGUI PrimaryCooldownText; // Reference to the TextMeshProUGUI component

    private PrimarySpell magicProjectile; // Reference to the MagicProjectile script

     private void Start()
    {
        magicProjectile = GameObject.FindWithTag("Player")?.GetComponent<PrimarySpell>();
        if (magicProjectile != null) PrimaryCooldownText.text = "Ready";
    }

    private void Update()
    {
            // Update the cooldown UI text based on remaining cooldown time
            float remainingCooldown = Mathf.Max(0f, magicProjectile.lastFireTime + magicProjectile.cooldownTime - Time.time);
            PrimaryCooldownText.text = remainingCooldown.ToString("F1"); // Display remaining cooldown time with one decimal place
    }
}

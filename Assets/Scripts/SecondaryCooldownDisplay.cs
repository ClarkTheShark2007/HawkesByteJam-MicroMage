using UnityEngine;
using TMPro;

public class SecondaryCooldownDisplay : MonoBehaviour
{
    public TextMeshProUGUI SecondaryCooldownText; // Reference to the TextMeshProUGUI component

    private SecondarySpell magicProjectile; // Reference to the MagicProjectile script

     private void Start()
    {
        magicProjectile = GameObject.FindWithTag("Player")?.GetComponent<SecondarySpell>();
        if (magicProjectile != null) SecondaryCooldownText.text = "Ready";
    }

    private void Update()
    {
            // Update the cooldown UI text based on remaining cooldown time
            float remainingCooldown = Mathf.Max(0f, magicProjectile.lastFireTime + magicProjectile.cooldownTime - Time.time);
            SecondaryCooldownText.text = remainingCooldown.ToString("F1"); // Display remaining cooldown time with one decimal place
    }
}

using UnityEngine;
using TMPro;

public class CooldownDisplay : MonoBehaviour
{
    public TextMeshProUGUI cooldownText; // Reference to the TextMeshProUGUI component

    private MagicProjectile magicProjectile; // Reference to the MagicProjectile script

     private void Start()
    {
        magicProjectile = GameObject.FindWithTag("Player")?.GetComponent<MagicProjectile>();
        if (magicProjectile != null) cooldownText.text = "Ready";
    }

    private void Update()
    {
            // Update the cooldown UI text based on remaining cooldown time
            float remainingCooldown = Mathf.Max(0f, magicProjectile.lastFireTime + magicProjectile.cooldownTime - Time.time);
            cooldownText.text = remainingCooldown.ToString("F1"); // Display remaining cooldown time with one decimal place
    }
}

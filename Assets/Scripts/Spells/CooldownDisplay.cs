using UnityEngine;
using TMPro;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField]
    private int spellIndex=0;


    public TextMeshProUGUI cooldownText; // Reference to the TextMeshProUGUI component

    private Spell magicProjectile; // Reference to the MagicProjectile script

     private void Start()
    {
        magicProjectile = GameObject.FindWithTag("Player")?.GetComponents<Spell>()[spellIndex];
        if (magicProjectile != null) cooldownText.text = "Ready";
    }

    private void Update()
    {
            // Update the cooldown UI text based on remaining cooldown time
            float remainingCooldown = Mathf.Max(0f, magicProjectile.lastFireTime + magicProjectile.cooldownTime - Time.time);
            cooldownText.text = remainingCooldown.ToString("F1"); // Display remaining cooldown time with one decimal place
    }
}

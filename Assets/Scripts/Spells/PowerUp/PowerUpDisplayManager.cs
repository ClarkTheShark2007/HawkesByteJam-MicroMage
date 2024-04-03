using UnityEngine;
using TMPro;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField]
    private int spellIndex=0;


    public TextMeshProUGUI cooldownText; // Reference to the TextMeshProUGUI component
    private InventoryManager inventoryManager;
    private Spell magicProjectile; // Reference to the MagicProjectile script

     private void Start()
    {
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
        magicProjectile =  inventoryManager.getSpellAtIndex(spellIndex);    
        if (magicProjectile != null) cooldownText.text = "Ready";
    }

    private void Update()
    {
            magicProjectile =  inventoryManager.getSpellAtIndex(spellIndex);
            // Update the cooldown UI text based on remaining cooldown time
            float remainingCooldown = Mathf.Max(0f, magicProjectile.lastFireTime + magicProjectile.cooldownTime - Time.time);
            cooldownText.text = remainingCooldown.ToString("F1"); // Display remaining cooldown time with one decimal place
    }
}

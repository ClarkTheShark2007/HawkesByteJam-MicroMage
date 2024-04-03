using UnityEngine;
using TMPro;

public class PowerUpDisplayManager : MonoBehaviour
{
    [SerializeField]
    private int spellIndex=0;


    public TextMeshProUGUI PowerUpText; // Reference to the TextMeshProUGUI component
    private InventoryManager inventoryManager;
    private Spell magicProjectile; // Reference to the MagicProjectile script

     private void Start()
    {
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
        magicProjectile =  inventoryManager.getSpellAtIndex(spellIndex);    
        if (magicProjectile != null) PowerUpText.text = "Ready";
    }

    private void Update()
    {
            magicProjectile =  inventoryManager.getSpellAtIndex(spellIndex);
            // Update the cooldown UI text based on remaining cooldown time
            float remainingPowerUp = magicProjectile.powerUpTime;
            PowerUpText.text = remainingPowerUp.ToString("F1"); // Display remaining cooldown time with one decimal place
    }
}

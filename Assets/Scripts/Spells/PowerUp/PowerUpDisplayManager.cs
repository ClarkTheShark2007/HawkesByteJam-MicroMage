using UnityEngine;
using TMPro;

public class PowerUpDisplayManager : MonoBehaviour
{
    [SerializeField]
    private int spellIndex=0;


    public TextMeshProUGUI PowerUpText; // Reference to the TextMeshProUGUI component
    private InventoryManager inventoryManager;
    private Spell magicProjectile; // Reference to the MagicProjectile script
    private PowerUpManager powerUpManager;

    private void Start()
    {
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
        powerUpManager = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PowerUpManager>(); 
        magicProjectile =  inventoryManager.getSpellAtIndex(spellIndex);    
        if (magicProjectile != null) PowerUpText.text = "Ready";
    }

    private void Update()
    {
            magicProjectile =  inventoryManager.getSpellAtIndex(spellIndex);
            // Update the cooldown UI text based on remaining cooldown time
            if(powerUpManager.poweredUp[spellIndex])
            {
            float remainingPowerUp = Mathf.Max(0f, powerUpManager.Lastpoweruptime[spellIndex] + magicProjectile.powerUpTime - Time.time);
            PowerUpText.text = remainingPowerUp.ToString("F1"); // Display remaining PowerUp time with one decimal place
            }
            else 
            {
                PowerUpText.text = "∞";
            }
    }
}

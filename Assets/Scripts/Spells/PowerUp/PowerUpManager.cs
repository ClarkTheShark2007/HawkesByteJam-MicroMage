using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private InventoryManager inventoryManager;
    public bool[] poweredUp; //hes just powered up like that
    public float[] Lastpoweruptime;
     private void Start()
    {
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
        Lastpoweruptime = new[]{0f, 0f};
        poweredUp = new[]{false, false};
    }
    public void startPowerUp(Spell addSpell, int spellIndex)
    {
        StartCoroutine(endPowerUp(spellIndex));
        inventoryManager.setSpellAtIndex(addSpell, spellIndex);
        Lastpoweruptime[spellIndex] = Time.time;
        poweredUp[spellIndex] = true;
    }

    IEnumerator endPowerUp(int spellIndex)
    {
        yield return new WaitForSeconds(inventoryManager.getSpellAtIndex(spellIndex).powerUpTime);
        inventoryManager.resetSpell(spellIndex);
        poweredUp[spellIndex] = false;
    }
}

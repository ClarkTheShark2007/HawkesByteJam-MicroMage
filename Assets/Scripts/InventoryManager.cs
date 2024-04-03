using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    
    private Spell[] spells;
    

    // Start is called before the first frame update
    void Awake()
    {
        Spell coneShot, bolt;
        bolt = GameObject.FindGameObjectWithTag("Player")?.GetComponents<Spell>()[0];
        coneShot = GameObject.FindGameObjectWithTag("Player")?.GetComponents<Spell>()[1];

        spells = new Spell[]{bolt, coneShot};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Spell getSpellAtIndex(int spellIndex)
    {
        if(spellIndex < spells.Length)
        {
            return spells[spellIndex];
        }
        else
        {
            return null;
        }

    }
    public void setSpellAtIndex(Spell addSpell, int spellIndex)
    {
        if(spellIndex < spells.Length)
        {
            spells[spellIndex] = addSpell;
            StartCoroutine(endPowerUp(spellIndex));
            return;
        }
        else
        {
            return;
        }
    }
    
    public void resetSpell(int spellIndex)
    {
        if (spellIndex == 0)
        {
            Spell bolt;
            bolt = GameObject.FindGameObjectWithTag("Player")?.GetComponents<Spell>()[0];
            spells[spellIndex] = bolt;
        }
        else 
        {
            Spell coneShot;
            coneShot = GameObject.FindGameObjectWithTag("Player")?.GetComponents<Spell>()[1];
            spells[spellIndex] = coneShot;
        }
    }

    IEnumerator endPowerUp(int spellIndex)
    {
        yield return new WaitForSeconds(getSpellAtIndex(spellIndex).powerUpTime);
        resetSpell(spellIndex);
    }
}

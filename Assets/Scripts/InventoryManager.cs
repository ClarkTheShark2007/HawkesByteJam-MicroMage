using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    
    private Spell[] spells;

    // Start is called before the first frame update
    void Start()
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
            return;
        }
        else
        {
            return;
        }
    }
}

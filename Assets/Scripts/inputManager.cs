using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    private Spell primary;
    private Spell secondary;
    void Start()
    {
        primary = GameObject.FindWithTag("Player")?.GetComponents<Spell>()[0];
        secondary = GameObject.FindWithTag("Player")?.GetComponents<Spell>()[1];
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= primary.lastFireTime + primary.cooldownTime)
        {
            primary.castSpell();
        }
         if(Input.GetMouseButtonDown(1) && Time.time >= secondary.lastFireTime + secondary.cooldownTime)
        {
           secondary.castSpell();
        }


    }
}

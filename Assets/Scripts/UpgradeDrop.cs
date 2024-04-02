using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Loot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnenmyHealth.OnEnemyDeath += spawnLoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnLoot()
    {
        Debug.Log("DED: " + this.gameObject.name);
    }
}

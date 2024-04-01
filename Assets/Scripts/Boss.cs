using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject blueEnemy1;
    public GameObject blueEnemy2;

    public GameObject redEnemy1;
    public GameObject redEnemy2;

    public GameObject Walls;
    private void OnEnable() 
    {
        EnenmyHealth.OnEnemyDeath += MiniBoss;
    }
        private void OnDisable() 
    {
        EnenmyHealth.OnEnemyDeath -= MiniBoss;
    }

    // Start is called before the first frame update
    public void MiniBoss()
    {
        blueEnemy1.SetActive(true);
        blueEnemy2.SetActive(true);
        redEnemy1.SetActive(true);
        redEnemy2.SetActive(true);
        Walls.SetActive(false);          
    }
}

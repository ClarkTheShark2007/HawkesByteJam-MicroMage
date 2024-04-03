using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject Enemys;

    public GameObject Walls;

    public AudioSource stopTheme;

    public AudioSource deathTheme;

    void Start() 
    {
        stopTheme.Stop();
    }

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
        Enemys.SetActive(true);
        Walls.SetActive(false);
        stopTheme.Play();
        deathTheme.Stop();          
    }
}

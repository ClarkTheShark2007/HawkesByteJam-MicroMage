using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private void OnEnable() 
    {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
    }
        private void OnDisable() 
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu() 
    {
        StartCoroutine(WaitForFunction());
    }
    
    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(3);
        gameOverMenu.SetActive(true);
    }

}

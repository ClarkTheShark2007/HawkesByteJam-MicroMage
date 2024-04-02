using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject levelScreen;

    public GameObject Player;

    public AudioSource bossTheme;
    public AudioSource mainTheme;

    void Start() 
    {
        levelScreen.SetActive(true);
        Player.SetActive(false);
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad() 
    {
        yield return new WaitForSeconds(3);
        levelScreen.SetActive(false);
        Player.SetActive(true);
    }


    private void OnEnable() 
    {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
    }
        private void OnDisable() 
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void EnableGameOverMenu() 
    {
        StartCoroutine(WaitForFunction());
        bossTheme.Stop();
        mainTheme.Stop();
    }
    
    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(3);
        gameOverMenu.SetActive(true);
    }

    public void Menu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

}

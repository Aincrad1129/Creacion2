using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public string sceneName;
    public GameObject pauseMenuUI;
    PlayerControls playerControls;

    private void OnEnable()
    {
        if (playerControls == null)
        {
           
            playerControls = new PlayerControls();
            
            playerControls.UI.Pause.performed += i => setPause();
        }

        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void setPause()
    {
        gameManager.setPause(!gameManager.pause);
        pauseMenuUI.SetActive(gameManager.pause);
        Time.timeScale = gameManager.pause ? 0 : 1;
    }

   
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        gameManager.setPause(false);
        Time.timeScale = 1f;
    }
    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        gameManager.setPause(true);
        Time.timeScale = 0f;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

  
}



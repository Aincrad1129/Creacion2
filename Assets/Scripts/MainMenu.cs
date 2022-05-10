using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;

    [SerializeField] private GameObject controlScreen;
    [SerializeField] private GameObject firstButtonControlScreen;
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject firstButtonMenuPrincipal;
    [SerializeField] private GameObject opcionesMenu;
    [SerializeField] private GameObject firstButtonOpcionesMenu;
    void Start() {
        controlScreen.SetActive(false);
        opcionesMenu.SetActive(false);

    }
    public void loadingScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void OpenControlScreen() {
        menuPrincipal.SetActive(false);
        controlScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(firstButtonControlScreen);
    }
    public void OpenOpcionesMenu() 
    {
        menuPrincipal.SetActive(false);
        opcionesMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(firstButtonOpcionesMenu);

    }

    public void OPenMenuPrincipal() 
    {
        menuPrincipal.SetActive(true);
        controlScreen.SetActive(false);
        opcionesMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(firstButtonMenuPrincipal);

    }
}

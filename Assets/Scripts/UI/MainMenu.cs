using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : BaseMenu
{
    [Header("Menu Buttons")]
    [SerializeField] private SelectButton ButtonJugar;
    [SerializeField] private SelectButton ButtonOpciones;
    [SerializeField] private SelectButton ButtonCreditos;
    [SerializeField] private SelectButton ButtonSalir;
    [SerializeField] private GameObject BtnStart;

    [Header("Menus")]
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject ControlesPanel;
    [SerializeField] private GameObject CreditosPanel;

    [Header("Materials")]
    [SerializeField] Material[] ScifiGraph;
    [SerializeField] Material[] UIGraph;

    [Header("Configuration")]
    [SerializeField] float Intensity = 2f;

    [Header("Sound")]
    [SerializeField] private AudioSource musicaMenu;

    [Header("Animacion Creditos")]
    [SerializeField] private Animar_texto animar_Texto;

    void Start() {

        musicaMenu.Play();
        StartPanel.SetActive(true);
        BtnStart.SetActive(true);
        MenuPanel.SetActive(false);
        CreditosPanel.SetActive(false);
        ButtonJugar.Select();
        foreach (Material item in ScifiGraph)
        {
            item.SetColor("_ScanColor", Color.cyan);
            item.SetFloat("_ScanIntensity", 10);
        }
        foreach (Material item in UIGraph)
        {
            item.SetFloat("_BreatheEffect", 0);
        }
        playerControls.UI.Pause.performed += i => StartBtn();
        playerControls.UI.Cancel.performed += i => BackBtn();
    }


    public void StartBtn()
    {
        if (ControlesPanel.activeInHierarchy || CreditosPanel.activeInHierarchy) return;
        BtnStart.SetActive(false);
        MenuPanel.SetActive(true);
        foreach (Material item in ScifiGraph)
        {
            item.SetColor("_ScanColor", Color.white);
            item.SetFloat("_ScanIntensity", Intensity);
        }
    }

    public void BackBtn()
    {
        if (CreditosPanel.activeInHierarchy) animar_Texto.PararDeEscribir();
        ControlesPanel.SetActive(false);
        CreditosPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void Controles()
    {
        ControlesPanel.SetActive(true);
        MenuPanel.SetActive(false);
       
    }

    public void Creditos()
    {
        CreditosPanel.SetActive(true);
        animar_Texto.ComenzarAEscribir();
        MenuPanel.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(2);
    }

    public void Salir()
    {
        Application.Quit();
    }
}

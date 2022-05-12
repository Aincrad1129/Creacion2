using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : BaseMenu
{
    [Header("Menu Buttons")]
    [SerializeField] private SelectButton ButtonJugar;
    [SerializeField] private SelectButton ButtonOpciones;
    [SerializeField] private SelectButton ButtonCreditos;
    [SerializeField] private SelectButton ButtonSalir;

    [Header("Menus")]
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject BtnStart;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject ControlesPanel;

    [Header("Materials")]
    [SerializeField] Material[] ScifiGraph;
    [SerializeField] Material[] UIGraph;

    [Header("Configuration")]
    [SerializeField] float Intensity = 2f;


    void Start() {
        StartPanel.SetActive(true);
        BtnStart.SetActive(true);
        MenuPanel.SetActive(false);
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
        ButtonJugar.onClick.AddListener(() => GoToMenu(MenuPanel));
    }

    public void StartBtn()
    {
        BtnStart.SetActive(false);
        MenuPanel.SetActive(true);
        foreach (Material item in ScifiGraph)
        {
            item.SetColor("_ScanColor", Color.white);
            item.SetFloat("_ScanIntensity", Intensity);
        }
    }
}

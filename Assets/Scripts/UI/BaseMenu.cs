using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseMenu : MonoBehaviour
{
    [Header("Base Menu")]
    protected PlayerControls playerControls;
    [SerializeField] private GameObject fadeInImage;


    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    protected virtual void Update()
    {
        //Empty
    }

    protected virtual void OnEnable()
    {
        playerControls.Enable();
    }

    protected virtual void OnDisable()
    {
        playerControls.Disable();
    }

    public void GoToMenu(GameObject menuToLoad)
    {
        fadeInImage.SetActive(true);
        menuToLoad.SetActive(true);
    }

}

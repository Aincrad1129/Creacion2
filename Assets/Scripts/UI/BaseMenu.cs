using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseMenu : MonoBehaviour
{
    [Header("Base Menu")]
    protected PlayerControls playerControls;


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


}

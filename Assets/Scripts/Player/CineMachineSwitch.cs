using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMachineSwitch : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerControls playerControls;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            if(!gameManager.pause || gameManager.finalChallengeUnloke) playerControls.PlayerActions.ChangeCamera.performed += i => animator.SetBool("WorldCamera", !animator.GetBool("WorldCamera"));
            
        }

        playerControls.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour
{
    [SerializeField] private PlayerControls playerControls;
    private Camera cam;
    public bool canDoAction = false;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject actionImageUI;

    [Serializable]
    public class ActionButtonEvent : UnityEvent { }

    [SerializeField]
    private ActionButtonEvent actionButtonEvent = new ActionButtonEvent();
    public ActionButtonEvent onactionButtonEvent { get { return actionButtonEvent; } set { actionButtonEvent = value; } }


    private void Awake(){
        cam = Camera.main;
        actionImageUI.SetActive(false);

    }


    private void OnEnable() {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerActions.Action.performed += i => actionButtonEventTriggered();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canDoAction = true;
            actionImageUI.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {


        
        actionImageUI.transform.position = playerTransform.position + (Vector3.up * 0.25f);
        actionImageUI.transform.forward = -cam.transform.forward;



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            canDoAction = false;
            actionImageUI.SetActive(false);
        }
    }
    public void actionButtonEventTriggered()
    {
        if(canDoAction)
        onactionButtonEvent.Invoke();
    }
}


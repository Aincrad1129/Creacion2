using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    [SerializeField]private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        var playersMovement = FindObjectsOfType<PlayerMovement>();
        var index = playerInput.playerIndex;
        playerMovement = playersMovement.FirstOrDefault(x => x.getPlayerindex() == index);
        gameManager.players[index].player.isActive = true;   
    }

    // Update is called once per frame
    public void OnMoveInput(InputAction.CallbackContext context) => playerMovement.Move(context.ReadValue<float>());
    public void JumpInput(InputAction.CallbackContext context) => playerMovement.Jump();

}

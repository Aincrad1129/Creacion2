//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    private Animator playerAnimator ;
    private Rigidbody playerRigidbody ;
    private Vector3 moveVec;
    private bool isGround;
    private Transform cameraTransform;
    private Vector3 directionInput;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float playerSpeed;

    private void Awake()
    {
        playerAnimator = this.GetComponent<Animator>();
        playerRigidbody = this.GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }   
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => directionInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.Jump.performed += i => Jump();
        }

        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         isGround = OnGround();
        if (isGround)
        {
            playerAnimator.SetBool("Ground", true);

        }
        else { 
            playerAnimator.SetBool("Ground", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetFloat("Falling", playerRigidbody.velocity.y);
        }
        Move();
        Rotate();
        
    }
    private void LateUpdate()
    {
        
    }

    public void Move() {
        playerAnimator.SetFloat("Run",   Mathf.Clamp(Mathf.Abs(directionInput.magnitude),0,1));
        moveVec = cameraTransform.forward * directionInput.y;
        moveVec = moveVec + cameraTransform.right * directionInput.x;
        
        moveVec.Normalize();
        this.transform.position += moveVec * playerSpeed * Time.deltaTime;
        
    }
    public void Jump()
    {
        if (isGround)
        {
            playerAnimator.SetBool("Jump", true);
            playerAnimator.SetBool("Ground", false);
            playerRigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void Rotate() {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraTransform.forward * directionInput.x;
        targetDirection = targetDirection + cameraTransform.right * -directionInput.y;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }


 
    private bool OnGround() => Physics.SphereCast(this.transform.position, this.GetComponent<CapsuleCollider>().radius, Vector3.down, out RaycastHit hit, (this.GetComponent<CapsuleCollider>().height / 2) - (this.GetComponent<CapsuleCollider>().radius / 2));
 
    
}

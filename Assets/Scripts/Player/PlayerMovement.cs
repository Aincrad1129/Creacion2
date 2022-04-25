//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Character Scriptable Object")]
    [Tooltip ("Se encuentra en la ruta Configuration/ScriptableObject/Character")]
    [SerializeField] public  Character character;
    private Animator playerAnimator => this.GetComponent<Animator>();
    private Rigidbody playerRigidbody => this.GetComponent<Rigidbody>();
    private Vector3 moveVec;
    private bool isGround;
    private float idleTime;


    private void Awake()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IdleAnim();
         isGround = OnGround2();
        if (isGround)
        {
            playerAnimator.SetBool("Ground", true);

        }
        else { 
            playerAnimator.SetBool("Ground", false);
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetFloat("Falling", playerRigidbody.velocity.y);
        }
       


    }
    private void IdleAnim() {
        if (moveVec.x == 0) idleTime += Time.deltaTime;
        else idleTime = 0;
        if (idleTime > 3 )
        {
            if (!playerAnimator.GetBool("IdleAnim"))
            {
                playerAnimator.SetInteger("IdleState", Random.Range(1, 2));
            }
            playerAnimator.SetBool("IdleAnim", true);      
        }
        else {
            playerAnimator.SetBool("IdleAnim", false);
        }
    }
    private void LateUpdate()
    {
        this.transform.position +=  moveVec *character.Velocity * Time.deltaTime;
    }

    public int getPlayerindex() => character.index;
    public void Move(float direction) { 
        moveVec = Vector3.right * direction;
        playerAnimator.SetFloat("Run",Mathf.Abs(direction));
        if (moveVec.x > 0) this.transform.rotation = Quaternion.Euler(Vector3.zero);
        if (moveVec.x < 0) this.transform.rotation = Quaternion.Euler(Vector3.up * 180);
    }
    public void Jump()
    {
        if (isGround)
        {
            playerAnimator.SetBool("Jump", true);
            playerAnimator.SetBool("Ground", false);
            playerRigidbody.AddForce(Vector3.up * character.JumpVelocity, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door"))
        {
            other.gameObject.SetActive(false);
        }
    }
 
    private void ParkourAcionInput()
    {
    }

    private void ActionInput()
    {
    }

    private void CrouchInput()
    {
    }

    private bool OnGround()  => Physics.Raycast(this.transform.position, Vector3.down, (this.GetComponent<CapsuleCollider>().height / 2) + 0.1f);

    private bool OnGround2() {
         return Physics.SphereCast(this.transform.position, this.GetComponent<CapsuleCollider>().radius, Vector3.down, out RaycastHit hit, (this.GetComponent<CapsuleCollider>().height / 2) - (this.GetComponent<CapsuleCollider>().radius / 2));
 
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.down * (this.GetComponent<CapsuleCollider>().height / 2));
        Gizmos.DrawSphere(this.transform.position + Vector3.down * ((this.GetComponent<CapsuleCollider>().height / 2) - (this.GetComponent<CapsuleCollider>().radius/2)), this.GetComponent<CapsuleCollider>().radius);
    }
    */
}

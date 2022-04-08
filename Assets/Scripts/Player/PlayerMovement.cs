using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Character Scriptable Object")]
    [Tooltip ("Se encuentra en la ruta Configuration/ScriptableObject/Character")]
    [SerializeField] private Character player;
    private Rigidbody playerRigidbody => this.GetComponent<Rigidbody>();
    private Vector3 moveVec;

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
    }
    private void LateUpdate()
    {
        this.transform.position +=  moveVec *player.Velocity * Time.deltaTime;
    }

    public int getPlayerindex() => player.index;
    public void Move(float direction) { 
        moveVec = Vector3.right * direction;
        if (moveVec.x > 0) this.transform.rotation = Quaternion.Euler(Vector3.zero);
        if (moveVec.x < 0) this.transform.rotation = Quaternion.Euler(Vector3.up * 180);
    }
    public void Jump() {
        if(OnGround())playerRigidbody.AddForce(Vector3.up * player.JumpVelocity, ForceMode.Impulse);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravity;
    private CharacterController CC;
    public float Movespeed=-8f;  //movespeed=-8/5
    public float mosped = -1.6f;
    public float JumpSpeed;
    public Vector3 moveV =Vector3.zero;
    private Animator animator;
    public float forwardM=1f;
    public bool Button;
    private void Start()
    {
        CC=GetComponent<CharacterController>();
        animator=GetComponent<Animator>();
    }
    // Update is called once per frame
    
    private void Update()
    {
        moveV.z=Input.GetAxis("Horizontal")*Movespeed;
        //moveV.z=Input.acceleration.x*Movespeed;
        moveV.x=forwardM;
        //if(Input.GetButtonDown("Jump") && CC.isGrounded){
        if(Button==true && CC.isGrounded){
            animator.SetTrigger("Jump");
            moveV.y=JumpSpeed;
            Button=false;
        }
        moveV.y-=gravity*Time.deltaTime;
        
        
    }
    private void LateUpdate(){
        CC.Move(moveV*Time.deltaTime);
    }
    public void Jumpbutton(){
        Button = true;
    }
}

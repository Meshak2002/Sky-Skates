using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravity;
    public CharacterController CC;
    public float Movespeed;  //movespeed=-8/5
    public float mosped ; //Used to increase speed after collection certain coins
    public float JumpSpeed;
    public Vector3 moveV =Vector3.zero;
    private Animator animator;
    public float forwardM;
    public bool Button,sidelock,gravitylock,jmplock;
    public Vector3 glob;
    private void Start()
    {
        CC=GetComponent<CharacterController>();
        animator=GetComponent<Animator>();
    }
    // Update is called once per frame
    
    private void Update()
    {
        if (sidelock == false)
        {
            moveV.x = Input.GetAxis("Horizontal") * Movespeed;
        }
        //moveV.z=Input.acceleration.x*Movespeed;
        
        moveV.z=forwardM;
        //if(Input.GetButtonDown("Jump") && CC.isGrounded){
        if(Button==true && CC.isGrounded){
            animator.SetTrigger("Jump");
            glob.y=JumpSpeed;
            Button=false;
        }
        if (gravitylock == false)
        {
            glob.y -= gravity * Time.deltaTime;
        }
        
        
    }
    private void LateUpdate(){
        CC.Move(this.transform.rotation*moveV*Time.deltaTime);  //If transform.rotation is not added .Move will take the reference of global vector ,but if it is added .Move will take the vector reference w.r.t transform.rotation
       if (gravitylock == false)
       {
            CC.Move(glob * Time.deltaTime);  //for gravity to be applied w.r.t global vector
        }
    }
    public void Jumpbutton(){
        if (jmplock == false)
        {
            Button = true;
        }
    }
}

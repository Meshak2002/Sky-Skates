using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth_look_at : MonoBehaviour
{
    public float speed =20f;
    public float x=10.588f;
    public float y=103.98f;
    public float z=6.196f;
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Angle_1")){
            x=10.588f;
            y=86.3f; //next 104.1(angle3)
            z=6.196f;
        }
        if(col.gameObject.CompareTag("Angle_2")){
            x=10.588f;
            y=104.1f; //next (angle4)
            z=6.196f;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Quaternion target_angle=Quaternion.LookRotation(target.position-this.transform.position);
        this.transform.rotation=Quaternion.RotateTowards(this.transform.rotation,Quaternion.Euler(x,y,z),speed*Time.deltaTime);
    }
}

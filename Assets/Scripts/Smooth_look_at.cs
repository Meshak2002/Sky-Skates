using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth_look_at : MonoBehaviour
{
    public float speed =20f;
    public float x;
    public float y;
    public float z;
    public void Start()
    {
       
        y = this.transform.eulerAngles.y;
        x = this.transform.eulerAngles.x;
        z = this.transform.eulerAngles.z;
        
    }
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Barrier 0")){
            y = 100.21f;
        }else if(col.gameObject.CompareTag("Barrier 1")){
            y = 93.8f;
        }
        else if (col.gameObject.CompareTag("Barrier 2")){
            y = 86.743f;
        }
        else if (col.gameObject.CompareTag("Barrier 3")){
            y = 81.8f;
        }
        else if (col.gameObject.CompareTag("Barrier 4")){
            y = 85.52f;
        }
        else if (col.gameObject.CompareTag("Barrier 5")){
            y = 96.76f;
        }
        else if (col.gameObject.CompareTag("Barrier 6")){
            y = 99.456f;
        }
        else if (col.gameObject.CompareTag("Barrier 7")){
            y = 99.4f;
        }
        else
        {
            Debug.Log("fk");
        }
    }

    // Update is called once per frame
    private void Update()
    {
       
        this.transform.rotation=Quaternion.RotateTowards(this.transform.rotation,Quaternion.Euler(x,y,z),speed*Time.deltaTime);
    }
}

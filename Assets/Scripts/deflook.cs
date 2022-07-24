using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deflook : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed =10f;
    public float x;
  

    // Update is called once per frame
    private void Update()
    {
        x=this.transform.rotation.x;
        this.transform.rotation=Quaternion.RotateTowards(this.transform.rotation,Quaternion.Euler(23.362f,-264.661f,0.656f),speed*Time.deltaTime);
        if(-x>0.13){ 
            this.GetComponent<deflook>().enabled=false;
    }
    }
}

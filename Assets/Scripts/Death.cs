using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject can; //end canvas
    public GameObject cscanvas; //score and coin canvas

    public void OnControllerColliderHit(ControllerColliderHit hit){
          if(hit.transform.tag == "Obstacles"){
                 this.GetComponent<Animator>().enabled=false;
                 this.GetComponent<PlayerMovement>().enabled=false;
                 this.GetComponent<Score>().enabled=false;
                 can.SetActive(true);
                 cscanvas.SetActive(false);
            this.gameObject.transform.tag = "PDead";
                 
        }
    }
    
}


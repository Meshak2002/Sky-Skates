using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausebutton : MonoBehaviour
{
    // Start is called before the first frame update
    public coins c;
    public Score s;
    public PlayerMovement pm;
    public GameObject pc; //pause canvas
    private void Update(){
            if (Input.GetKeyDown(KeyCode.Escape)) {
                 pm.enabled=false;
                 pc.SetActive(true);
                 c.enabled=false;
                 s.enabled=false;
            }
    }
    public void onclick(){
        pm.enabled=false;
        pc.SetActive(true);
        c.enabled=false;
        s.enabled=false;
        AudioListener.volume = 0;
    }
}

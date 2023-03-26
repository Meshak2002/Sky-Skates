using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausebutton : MonoBehaviour
{
    // Start is called before the first frame update
    public coins c;
    public Score s;
    public PlayerMovement pm;
    public GameObject pc; //pause canvas
    public Image hl;
    public static pausebutton pb;
    public AudioSource loopsound;
    private void Start()
    {
        if (pb == null)
        {
            pb = this;
        }
    }
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
        loopsound.Stop();
        //AudioListener.volume = 0;

    }
}

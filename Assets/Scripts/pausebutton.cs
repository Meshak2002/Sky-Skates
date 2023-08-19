using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausebutton : MonoBehaviour
{
    // Start is called before the first frame update
    private coins c;
    private Score s;
    private PlayerMovement pm;
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
                 pm = resource.instance.Player.GetComponent<PlayerMovement>();
                 c = resource.instance.Player.GetComponent<coins>();
                 s = resource.instance.Player.GetComponent<Score>();
                 pm.enabled=false;
                 pc.SetActive(true);
                 c.enabled=false;
                 s.enabled=false;
                loopsound.Stop();
            repeatpause();
        }
    }
    public void onclick(){
        pm = resource.instance.Player.GetComponent<PlayerMovement>();
        c = resource.instance.Player.GetComponent<coins>();
        s = resource.instance.Player.GetComponent<Score>();
        pm.enabled=false;
        pc.SetActive(true);
        c.enabled=false;
        s.enabled=false;
        loopsound.Stop();
        repeatpause();
        //AudioListener.volume = 0;

    }
    public void repeatpause()
    {
        pm = resource.instance.Player.GetComponent<PlayerMovement>();
        c = resource.instance.Player.GetComponent<coins>();
        s = resource.instance.Player.GetComponent<Score>();
        pm.enabled = false;
        pc.SetActive(true);
        c.enabled = false;
        s.enabled = false;
        loopsound.Stop();
    }
}

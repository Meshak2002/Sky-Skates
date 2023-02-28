using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RRB_buttons : MonoBehaviour
{
    // Start is called before the first frame update
     public coins c;
    public Score s;
    public PlayerMovement pm;
     public disable_startcanvas ds;
     public GameObject scorecoin_canvas;
    public AudioSource loopsound;
    private void Start(){
        pm = resource.instance.Player.GetComponent<PlayerMovement>();
        scorecoin_canvas.SetActive(false);
    }
    public void Replayf(){
         ds.falsefunc();
        SceneManager.LoadScene("SampleScene");
    }
    public void Replay(){
         
         ds.truefunc();
         ds.repla();
         SceneManager.LoadScene("SampleScene");
        
    }
    public void Resume(){
        AudioListener.volume=1;
        loopsound.Play();
        pm.enabled=true;
        this.gameObject.SetActive(false);
        c.enabled=true;
        s.enabled=true;
        scorecoin_canvas.SetActive(true);
    }
}

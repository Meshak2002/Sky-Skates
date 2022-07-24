using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    //public Total_coins tc;
    public Total_coins_score tc;
    public coins c;
    public Score s;
    public Text txt;
    public Text totscoretxt;
    public disable_startcanvas ds;
    
    public void Start(){
        txt.text=c.Totalcoins.ToString();
        totscoretxt.text=s.hiscore.ToString();
        tc.SaveCoins();
        AudioListener.volume=0;
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            s.neu.SetActive(false);
            ds.falsefunc();
            SceneManager.LoadScene("SampleScene");
            AudioListener.volume=0;
        }
    }
    public void Replayf(){
         s.neu.SetActive(false);
         ds.falsefunc();
         SceneManager.LoadScene("SampleScene");
         AudioListener.volume=0;
    }
    public void Replay(){
         AudioListener.volume=1;
         s.neu.SetActive(false);
         ds.truefunc();
         ds.repla();
         SceneManager.LoadScene("SampleScene");     
    }
}

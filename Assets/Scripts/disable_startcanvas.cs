using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable_startcanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public const string chk="Check";
    public int x;
    public GameObject go; //Start canvas
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;
    public GameObject cscanvas;
    public AudioSource loopsound;
    public const string yre="replychk";
    public int y=0;

    private void Start()
    {
       y=PlayerPrefs.GetInt(yre);   //on application quit or not
       x=PlayerPrefs.GetInt(chk);  //button based reply or back
       if(x==1 && y==0){  //disable startcanvas
           go.SetActive(false);
           ob1.GetComponent<PlayerMovement>().enabled=true;
           ob1.GetComponent<Score>().enabled=true;
           ob1.GetComponent<coins>().enabled=true;
           ob3.GetComponent<deflook>().enabled=true;
           ob2.SetActive(true);
           cscanvas.SetActive(true);
            AudioListener.volume = 1;
            loopsound.Play();
        }
       if(x==0 || y==1){  //enable startcan if button click or aplication exits
           go.SetActive(true);
            AudioListener.volume = 1;
            loopsound.Stop();
        }     
         
    }
    public void truefunc(){
        PlayerPrefs.SetInt(chk,1);
    }
    public void falsefunc(){
        PlayerPrefs.SetInt(chk,0);
    }
    public void OnApplicationQuit(){
        PlayerPrefs.SetInt(yre,1);
    }
    public void repla(){
        PlayerPrefs.SetInt(yre,0);
    }
}

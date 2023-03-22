using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startgame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;
    public GameObject coin_score_canvas;
    public GameObject neu;
    public GameObject store;   
    public GameObject self;
    public GameObject pickupstimeer;
    public AudioSource loopsound;
    private void Update()
    {
        if(ob1==null || ob3 == null)
        {
            ob1 = resource.instance.Player;
            ob3 = resource.instance.camer;
        }
    }
    private void Start()
    {
      
        neu.SetActive(false);
        ob1.GetComponent<PlayerMovement>().enabled=false;
        ob1.GetComponent<coins>().enabled=false;
        ob3.GetComponent<deflook>().enabled=false;
        ob1.GetComponent<Score>().enabled=false;
        ob2.SetActive(false);
        coin_score_canvas.SetActive(false);
        pickupstimeer.SetActive(false);
        ob1.GetComponent<Smooth_look_at>().enabled = false;
        //loopsound.Stop();
        AudioListener.volume=1;
    }

    // Update is called once per frame
    public void Startf(){
        //AudioListener.volume=1;
        loopsound.Play();
         this.gameObject.SetActive(false);
        pickupstimeer.SetActive(true);
        ob1.GetComponent<PlayerMovement>().enabled=true;
         ob1.GetComponent<Score>().enabled=true;
         ob1.GetComponent<coins>().enabled=true;
         ob3.GetComponent<deflook>().enabled=true;
         ob2.SetActive(true);
         coin_score_canvas.SetActive(true);
       
        
    }
    public void storeclick(){
        store.SetActive(true);
        self.SetActive(false);
    }
}

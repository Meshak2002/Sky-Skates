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
        AudioListener.volume=0;
    }

    // Update is called once per frame
    public void Startf(){
        AudioListener.volume=1;
         this.gameObject.SetActive(false);
         ob1.GetComponent<PlayerMovement>().enabled=true;
         ob1.GetComponent<Score>().enabled=true;
         ob1.GetComponent<coins>().enabled=true;
         ob3.GetComponent<deflook>().enabled=true;
         ob2.SetActive(true);
         coin_score_canvas.SetActive(true);
        pickupstimeer.SetActive(true);
    }
    public void storeclick(){
        store.SetActive(true);
        self.SetActive(false);
    }
}

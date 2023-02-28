using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinmultiplier : MonoBehaviour
{
    // Start is called before the first frame update
    private coins c;
    public GameObject bar,barr;
    public time tim;
    public float x,t=10;
    public bool go;
    public GameObject playerr;
    public Sprite logo;
    public Image holder;
    public static coinmultiplier instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        holder = pausebutton.pb.hl;
        playerr = resource.instance.Player;
        tim = GameObject.Find("Pickup Manager").GetComponent<time>();
        x = 1;
        c = resource.instance.Player.GetComponent<coins>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.SetParent(GameObject.Find("Pickup Manager").transform);
            c.amount = 2;
            this.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(finishtime());           
        }
    }
    private void Update()
    {
        if (bar != null)
        {
            bar.GetComponent<RectTransform>().localScale = new Vector3(3.709542f, 0.3380485f, 0.67292f);
        }
        if (playerr.transform.CompareTag("PDead"))
        {
            Destroy(this.gameObject);
        }
       
    }
    public void FixedUpdate()
    {
        if (GameObject.Find("Score & coin canvas +pasue") != null)
        {
            bar = GameObject.Find("Score & coin canvas +pasue").transform.GetChild(0).gameObject;
            barr = bar.transform.GetChild(0).gameObject;
        }


        if (go==true && x>0)
        {
            barr.GetComponent<RectTransform>().localScale = new Vector3(x,1,1);
            x -= 1.0f/t * Time.deltaTime;
            
        }
        else
        {
            x = 1;
        }
    }
    IEnumerator finishtime()
    {
        
        bar.SetActive(true);
        holder.sprite = logo;
        go = true;
        tim.upcomingpk = false;
        tim.hideunhi();
        yield return new WaitForSeconds(t);
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        bar.SetActive(false);
        barr.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        c.amount = 1;
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
    public void endthis()
    {
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        bar.SetActive(false);
        barr.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        c.amount = 1;
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinmultiplier : MonoBehaviour
{
    // Start is called before the first frame update
    private coins c;
    public GameObject bar,barr;
    public time tim;
    public float x,t=10;
    public bool go;
    public GameObject playerr;
    

    private void Start()
    {
        playerr = GameObject.Find("Player");
        tim = GameObject.Find("Pickup Manager").GetComponent<time>();
        x = 1;
        c = GameObject.Find("Player").GetComponent<coins>();
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
        go = true;
        tim.upcomingpk = false;
        yield return new WaitForSeconds(t);
        tim.upcomingpk = true;
        go = false;
        bar.SetActive(false);
        barr.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        c.amount = 1;
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}

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
    [HideInInspector] public float x,t;
    public float tt;
    public bool go;
    public GameObject playerr;
    public Sprite logo;
    public Image holder;
    public static coinmultiplier instance;
    public AudioClip pickupSound;

    private void Start()
    {
        if (instance == null)
            instance = this;
        holder = pausebutton.pb.hl;
        playerr = resource.instance.Player;
        tim = resource.instance.pickupmanager.GetComponent<time>();
        x = 1;
        c = resource.instance.Player.GetComponent<coins>();
        tt = t;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (resource.instance.pickupmanager.transform.childCount != 0)
            {
                foreach (Transform t in resource.instance.pickupmanager.transform)
                {
                    if (t.TryGetComponent<coinmultiplier>(out coinmultiplier cm))
                    {
                        cm.endthis();
                    }
                    else if (t.TryGetComponent<pickupmagnet>(out pickupmagnet pm))
                    {
                        pm.endthis();
                    }
                    else if (t.TryGetComponent<boot>(out boot b))
                    {
                        b.endthis();
                    }
                    else if (t.TryGetComponent<potion>(out potion p))
                    {
                        p.endthis();
                    }
                }
            }
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            this.transform.SetParent(resource.instance.pickupmanager.transform);
            
            c.amount = 2;
            this.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(finishtime());           
        }
    }
    private void Update()
    {
        if (bar != null)
        {
           // bar.GetComponent<RectTransform>().localScale = new Vector3(3.709542f, 0.3380485f, 0.67292f);
        }
        if (playerr.transform.CompareTag("PDead"))
        {
            Destroy(this.gameObject);
        }
       
    }
    public void FixedUpdate()
    {
        if (resource.instance.sccanvas != null)
        {
            bar = resource.instance.sccanvas.transform.GetChild(0).gameObject;
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
        Debug.Log("Time:" + t);
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

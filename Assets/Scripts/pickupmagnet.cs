using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupmagnet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject magnet;
    public time tim;
    public GameObject img, bar,playerr;
    [HideInInspector] public float t,x;
    public float tt;
    public bool go;
    public Sprite logo;
    public Image holder;
    public static pickupmagnet instance;
    void Start()
    {
        if (instance == null)
            instance = this;
        holder = pausebutton.pb.hl;
        playerr = resource.instance.Player;
        tim = GameObject.Find("Pickup Manager").GetComponent<time>();
        x = 1;
        tt = t;
    }
    private void Update()
    {
        if (bar != null)
        {
            //bar.GetComponent<RectTransform>().localScale = new Vector3(3.709542f, 0.3380485f, 0.67292f);
        }

        if (playerr.transform.CompareTag("PDead"))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("Score & coin canvas +pasue") != null)
        {
            bar = GameObject.Find("Score & coin canvas +pasue").transform.GetChild(0).gameObject;

            img = bar.transform.GetChild(0).gameObject;
        }
        
        magnet = resource.instance.Player.transform.GetChild(0).gameObject;
        if (go == true && x>0)
        {
            img.GetComponent<RectTransform>().localScale = new Vector3(x, 1, 1);
            //x -= 0.01f;
            x -= 1.0f / t * Time.deltaTime;

        }
        else
        {
            x = 1;
        }
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
            this.transform.SetParent(resource.instance.pickupmanager.transform);
            magnet.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wai());
        }

    }
    IEnumerator wai()
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
        magnet.SetActive(false);
        magnet.GetComponent<magnet>().cins.RemoveRange(0, magnet.GetComponent<magnet>().cins.Count);
        
        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
    public void endthis()
    {
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        magnet.SetActive(false);
        magnet.GetComponent<magnet>().cins.RemoveRange(0, magnet.GetComponent<magnet>().cins.Count);

        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
}

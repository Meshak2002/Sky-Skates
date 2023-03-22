using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject img, bar,player,playerr;
   [HideInInspector] public float t,x=0;
    public float tt;
    public time tim;
    public bool go;
    public Sprite logo;
    public Image holder;
    public static boot instance;

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
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (resource.instance.pickupmanager.transform.childCount != 0)
            {
                foreach(Transform t in resource.instance.pickupmanager.transform)
                {
                    if (t.TryGetComponent<coinmultiplier>(out coinmultiplier cm))
                    {
                        cm.endthis();
                    }else if (t.TryGetComponent<pickupmagnet>(out pickupmagnet pm))
                    {
                        pm.endthis();
                    }else if (t.TryGetComponent<boot>(out boot b))
                    {
                        b.endthis();
                    }else if (t.TryGetComponent<potion>(out potion p))
                    {
                        p.endthis();
                    }
                }
            }
            this.transform.SetParent(resource.instance.pickupmanager.transform);
            player = other.gameObject;
            this.GetComponent<MeshRenderer>().enabled=false;
            StartCoroutine(wai());
        }
    }
    public void FixedUpdate()
    {
        if (GameObject.Find("Score & coin canvas +pasue") != null)
        {
            bar = GameObject.Find("Score & coin canvas +pasue").transform.GetChild(0).gameObject;
            img = bar.transform.GetChild(0).gameObject;
        }       
        if (go == true && x>0)
        {
            img.GetComponent<RectTransform>().localScale = new Vector3(x, 1, 1);
            x -= 1.0f / t * Time.deltaTime;
        }
        else
        {
            x = 1;
        }
    }
    IEnumerator wai()
    {
        
        bar.SetActive(true);
        holder.sprite = logo;
        player.GetComponent<PlayerMovement>().JumpSpeed = 11;
        go = true;
        tim.upcomingpk = false;
        tim.hideunhi();
        yield return new WaitForSeconds(t);
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        player.GetComponent<PlayerMovement>().JumpSpeed = 6;
        
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
        player.GetComponent<PlayerMovement>().JumpSpeed = 6;
        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
}

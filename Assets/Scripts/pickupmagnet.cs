using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupmagnet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject magnet;
    public time tim;
    public GameObject img, bar,playerr;
    public float t=10,x;
    public bool go;

    
    void Start()
    {
        playerr = GameObject.Find("Player");
        tim = GameObject.Find("Pickup Manager").GetComponent<time>();
        x = 1;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("Score & coin canvas +pasue") != null)
        {
            bar = GameObject.Find("Score & coin canvas +pasue").transform.GetChild(0).gameObject;

            img = bar.transform.GetChild(0).gameObject;
        }
        
        magnet = GameObject.Find("Player").transform.GetChild(0).gameObject;
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
            this.transform.SetParent(GameObject.Find("Pickup Manager").transform);
            magnet.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wai());
        }

    }
    IEnumerator wai()
    {
        bar.SetActive(true);
        go = true;
        tim.upcomingpk = false;
        yield return new WaitForSeconds(t);
        tim.upcomingpk = true;
        go = false;
        magnet.SetActive(false);
        magnet.GetComponent<magnet>().cins.RemoveRange(0, magnet.GetComponent<magnet>().cins.Count);
        
        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}

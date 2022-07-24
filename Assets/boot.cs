using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject img, bar,player,playerr;
    public float t=10,x=0;
    public time tim;
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.SetParent(GameObject.Find("Pickup Manager").transform);
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
        player.GetComponent<PlayerMovement>().JumpSpeed = 11;
        go = true;
        tim.upcomingpk = false;
        yield return new WaitForSeconds(t);
        tim.upcomingpk = true;
        go = false;
        player.GetComponent<PlayerMovement>().JumpSpeed = 6;
        
        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);

    }
}

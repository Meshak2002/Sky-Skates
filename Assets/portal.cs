using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject portalManager;
    private bool once;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<CharacterController>().enabled == true)
            {
                if (once == false)
                {
                    if (time.instance.gameObject.transform.childCount > 0)
                    {
                        if (time.instance.gameObject.transform.GetChild(0).transform.name.Contains("Magnet"))
                        {
                            pickupmagnet.instance.endthis();
                            Debug.Log("Ended");
                        }else if (time.instance.gameObject.transform.GetChild(0).transform.name.Contains("Coin"))
                        {
                            coinmultiplier.instance.endthis();
                            Debug.Log("Ended");
                        }
                        else if (time.instance.gameObject.transform.GetChild(0).transform.name.Contains("Boot"))
                        {
                            boot.instance.endthis();
                            Debug.Log("Ended");
                        }
                    }
                    color_change.instance.portalcolide();
                    once = true;
                }
            }
            else
            {
                this.gameObject.SetActive(false);
            }
            //other.gameObject.GetComponent<Score>().activate_score = 5000;
        }
    }
}

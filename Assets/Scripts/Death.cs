using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject can; //end canvas
    public GameObject cscanvas; //score and coin canvas
    public Transform skateparent;
     GameObject active;
    private GameObject act2;
    public float initialFM, initialMS;
    public AudioSource damagsound,loopsound;
    private void OnEnable()
    {
        /*if (this.transform.name == "Player 2")
        {
            initialFM = resource.instance.Player.GetComponent<Death>().initialFM;
            initialMS = resource.instance.Player.GetComponent<Death>().initialMS;
            Debug.Log("C :::" + initialFM + "  " + initialMS);
        }*/
    }
    public void Start()
    {
        if (this.transform.name != "Player 2")
        {
            initialFM = this.GetComponent<PlayerMovement>().forwardM;
            initialMS = this.GetComponent<PlayerMovement>().Movespeed;
            Debug.Log("O :::" + initialFM + "  " + initialMS);
            setpare();
        }
        this.GetComponent<CharacterController>().enabled = true;
        if (this.transform.name == "Player 2")
        {
            initialFM = resource.instance.splayer.GetComponent<Death>().initialFM;
            initialMS = resource.instance.splayer.GetComponent<Death>().initialMS;
            Debug.Log("C :::" + initialFM + "  " + initialMS);
            findactiveskate();
            act2=skateparent.Find(active.transform.name).gameObject;
            act2.gameObject.SetActive(true);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacles")
        {
            this.GetComponent<PlayerMovement>().forwardM = initialFM;
            this.GetComponent<PlayerMovement>().Movespeed = initialMS;
            loopsound.Stop();
            damagsound.Play();
            StartCoroutine(wai());
            this.GetComponent<Score>().enabled = false;
            
            cscanvas.SetActive(false);
            this.gameObject.transform.tag = "PDead";

        }
    }
    IEnumerator wai()
    {
        this.GetComponent<PlayerMovement>().enabled = false;
        this.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(.1f);
        findactiveskate();
        setfree();
        this.GetComponent<Animator>().enabled = false;
        yield return new WaitUntil(()=>!damagsound.isPlaying);
        Debug.Log("Finished");
        can.SetActive(true);
    }
    public void setpare()
    {
        ShopManager.sm.box1.transform.SetParent(skateparent);
        ShopManager.sm.box2.transform.SetParent(skateparent);
        ShopManager.sm.boy1.transform.SetParent(skateparent);
        ShopManager.sm.boy2.transform.SetParent(skateparent);
        ShopManager.sm.boz1.transform.SetParent(skateparent);
        ShopManager.sm.boz2.transform.SetParent(skateparent);
    }
    public void setfree()
    {
        if (this.transform.name == "Player 2")
        {
            act2.transform.SetParent(null);
            act2.AddComponent<Rigidbody>();
        }
        else
        {
            active.transform.SetParent(null);
            active.AddComponent<Rigidbody>();
        }
    }
    void findactiveskate()
    {
        if (ShopManager.sm.box1.activeSelf)
        {
            active = ShopManager.sm.box1;
        }
        if (ShopManager.sm.box2.activeSelf)
        {
            active = ShopManager.sm.box2;
        }
        if (ShopManager.sm.boy1.activeSelf)
        {
            active = ShopManager.sm.boy1;
        }
        if (ShopManager.sm.boy2.activeSelf)
        {
            active = ShopManager.sm.boy2;
        }
        if (ShopManager.sm.boz1.activeSelf)
        {
            active = ShopManager.sm.boz1;
        }
        if (ShopManager.sm.boz2.activeSelf)
        {
            active = ShopManager.sm.boz2;
        }
    }
}


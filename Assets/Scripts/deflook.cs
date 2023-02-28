using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deflook : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed =10f;
    public float x;
    public GameObject player;
    public Transform targ;

    // Update is called once per frame
    public void Start()
    {
        StartCoroutine(Wait());
    }
    private void Update()
    {
        if (player == null)
        {
            Debug.Log("Waiting");
            player = resource.instance.Player;
        }
        if (targ == null)
        {
            targ = resource.instance.tarcam.transform;
        }
        

        x=this.transform.localEulerAngles.x;
        this.transform.rotation=Quaternion.RotateTowards(this.transform.rotation,targ.rotation,speed*Time.deltaTime);
        
        /*if(x== 15.0f)
        { 
            this.GetComponent<deflook>().enabled=false;
            player.GetComponent<Smooth_look_at>().enabled = true;
        }*/
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Wai");
        this.GetComponent<deflook>().enabled = false;
        player.GetComponent<Smooth_look_at>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mov;
    public List<GameObject> cins;
    public float attractspeed;
    public int y=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attractspeed = GameObject.Find("Player").GetComponent<PlayerMovement>().forwardM * 8f;
        if (cins.Count!=0)
        {
            
            if (cins[y]!=null)  //if (mov != null) 
            {                                                                                                                    //attractspeed*3                       
                cins[y].transform.position = Vector3.MoveTowards(cins[y].transform.position, this.gameObject.transform.position, attractspeed * Time.deltaTime);
  
            }
            if (cins[y] == null)  //if (mov != null) 
            {                                                                                                                    //attractspeed*3                       
                cins.RemoveAt(y);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            mov = other.gameObject;
            mov.GetComponent<Animator>().enabled = false;
            cins.Add(mov);
        }
    }
   

}

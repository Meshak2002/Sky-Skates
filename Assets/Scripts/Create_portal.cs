using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject portal;
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
            Debug.Log("Touched");
            if (other.gameObject.GetComponent<Score>().intscore > other.gameObject.GetComponent<Score>().activate_score)
            {
                portal.SetActive(true);
            }
        }
    }
}

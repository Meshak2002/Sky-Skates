using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPosition : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    private float dist;
    private float Targetdist= 1.325174f;
    public GameObject Coins;
    private GameObject thes;
    
    void OnEnable()
    {
        foreach (Transform g in Coins.transform)
        {
            if (g.GetChild(0).Find("updated coin"))
            {
                Debug.Log(g.GetChild(0).GetChild(0));
                g.GetChild(0).GetChild(0).GetComponent<Animator>().enabled = false;
                thes = g.GetChild(0).gameObject;

                if (Physics.Raycast(thes.transform.position, -transform.up, out hit))
                {
                    dist = hit.distance;
                    if (Targetdist != dist)
                    {
                        float add = Targetdist - dist;  // The value to be added to the position to get the target Distance
                        thes.transform.position = new Vector3(thes.transform.position.x, thes.transform.position.y + add, thes.transform.position.z);
                    }
                }
                g.GetChild(0).GetChild(0).GetComponent<Animator>().enabled = true;
            }
            else
            {
                Debug.Log(g+"NOte");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

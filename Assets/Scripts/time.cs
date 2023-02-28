using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> activepickups;
    public bool upcomingpk;
    public static time instance;
    void Start()
    {
        if (instance == null)
            instance = this;
        upcomingpk = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hideunhi()
    {
        if (activepickups.Count > 0)
        {
                for (int i = 0; i < activepickups.Count; i++)
                {
                    if (activepickups[i] == null)
                    {
                        activepickups.RemoveAt(i);
                    }
                    else{ 
                        if (activepickups[i].GetComponent<MeshRenderer>() == null)
                        {
                            if (activepickups[i].transform.Find("Boot") != null)
                            {
                                Debug.Log("yae");
                                activepickups[i].transform.Find("Boot").GetComponent<MeshRenderer>().enabled = upcomingpk;
                                activepickups[i].transform.Find("Boot").GetComponent<CapsuleCollider>().enabled = upcomingpk;
                            }
                        }

                        else
                        {
                            activepickups[i].GetComponent<MeshRenderer>().enabled = upcomingpk;
                            activepickups[i].GetComponent<CapsuleCollider>().enabled = upcomingpk;
                        }
                    }
                }
            }
        }
}

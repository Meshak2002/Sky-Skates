using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> activepickups;
    public bool upcomingpk;

    void Start()
    {
        upcomingpk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activepickups.Count > 0)
        {
            if (activepickups[0] == null)
            {
                activepickups.RemoveAt(0);
            }
            else
            {
                for (int i = 0; i < activepickups.Count; i++)
                {
                    activepickups[i].GetComponent<MeshRenderer>().enabled = upcomingpk;
                    activepickups[i].GetComponent<CapsuleCollider>().enabled = upcomingpk;
                }
            }
        }
    }
}

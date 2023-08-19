using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource : MonoBehaviour
{
    // Start is called before the first frame update
    public static resource instance;
    public GameObject pickupmanager, Player,camer,tarcam,splayer,scam,starcam,spawntile,sccanvas;
    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
       
    }
}

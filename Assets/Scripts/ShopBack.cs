using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    public GameObject startcan;

    // Update is called once per frame
    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape)){
             self.SetActive(false);
             startcan.SetActive(true);
         }
    }
}

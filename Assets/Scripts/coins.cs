using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour
{
    // Start is called before the first frame update
    public int coin = 0;
    public int Totalcoins;
    public Text text;
    public Text text2;
    public Text runtxt;
    public int amount;
    private void Start()
    {
        amount = 1;
    }

    private void OnGUI(){
   runtxt.text=coin.ToString();
   text.text=coin.ToString();
   text2.text=coin.ToString();
}
}

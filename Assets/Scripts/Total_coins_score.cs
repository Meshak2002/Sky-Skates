using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Total_coins_score : MonoBehaviour
{
    // Start is called before the first frame update
    public coins c;
    public Score s;
     public const string Playr_Pref="Totcoins";
     public const string Pleyr_pref="Hiscore";
     private void Awake(){
        c.Totalcoins=PlayerPrefs.GetInt(Playr_Pref);
     }
     private void Update(){
        s.hiscore=PlayerPrefs.GetInt(Pleyr_pref);
        //c.Totalcoins=PlayerPrefs.GetInt(Playr_Pref);
     }
    public void SaveCoins(){
        PlayerPrefs.SetInt(Playr_Pref,c.Totalcoins);
    }
    public void SaveScore(){
        PlayerPrefs.SetInt(Pleyr_pref,s.intscore);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour 
{
    // Start is called before the first frame update
    string GameID ="4436907";
    bool testmode=false;
    string InterstitialAdID="Interstitial_Android";
    void Start()
    {
        Advertisement.Initialize(GameID,testmode);
    }

     public void DisplayInterstitialAds(){
         if(Advertisement.IsReady()){
            Advertisement.Show(InterstitialAdID);
         }
         else
         {
            print("Please Check your connection");
         }
     }
}

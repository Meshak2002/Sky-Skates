using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ShopBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    public GameObject startcan;
    public Transform o, i;
    public Transform[] scrollview;
    public GameObject Upanel;
    public Button Ubutton, exit;
    public Button[] Upgrade;
    public Transform[] barsize;
    public TextMeshProUGUI[] amount_text;
    public Animator Up;
    public UPG_values upv;
    public int coins;
    string path;
    public GameObject[] pickups;
    public AudioSource upsound;

    public void OnEnable()
    {
        path = Application.persistentDataPath + "UpgradeData.json";
        Debug.Log(path);
    }
    public void UPbuttonClick()
    {
        Ubutton.interactable = false;
        falsescroll();
        Upanel.GetComponent<RectTransform>().anchoredPosition = i.GetComponent<RectTransform>().anchoredPosition;
        Upanel.GetComponent<RectTransform>().localScale = i.GetComponent<RectTransform>().localScale;
        Upanel.SetActive(true);
        Up.SetBool("Open", true);
        StartCoroutine("opwai");
    }
    public void Start()
    {
        coins = resource.instance.Player.GetComponent<coins>().Totalcoins;
        tocl();  //load class
        cstoBarUPdate();  //load class data to UI
        Upanel.SetActive(false);
        //exit.onClick.AddListener(()=>exituppanel());
    }
    // Update is called once per frame
    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape)){
             exituppanel();
             self.SetActive(false);
             startcan.SetActive(true);
         }
    }
    public void falsescroll()
    {
        foreach(Transform t in scrollview)
        {
            t.gameObject.SetActive(false);
        }
    }public void truescroll()
    {
        foreach(Transform t in scrollview)
        {
            t.gameObject.SetActive(true);
        }
    }
    public void exituppanel()
    {
        Ubutton.interactable = true;
        Upanel.GetComponent<RectTransform>().anchoredPosition = o.GetComponent<RectTransform>().anchoredPosition;
        Upanel.GetComponent<RectTransform>().localScale = o.GetComponent<RectTransform>().localScale;
        Up.SetBool("Open", false);
        StartCoroutine("wai");
    }
    IEnumerator wai()
    {
        yield return new WaitUntil(() => Up.GetCurrentAnimatorStateInfo(0).IsName("Closed"));
        Upanel.GetComponent<RectTransform>().anchoredPosition = o.GetComponent<RectTransform>().anchoredPosition;
        Upanel.GetComponent<RectTransform>().localScale = o.GetComponent<RectTransform>().localScale;
        Upanel.SetActive(false);
        truescroll();
    }
    IEnumerator opwai()
    {
        Debug.Log("OP");
        yield return new WaitUntil(() => Up.GetCurrentAnimatorStateInfo(0).IsName("Opened"));
        Upanel.GetComponent<RectTransform>().anchoredPosition = i.GetComponent<RectTransform>().anchoredPosition;
        Upanel.GetComponent<RectTransform>().localScale = i.GetComponent<RectTransform>().localScale;
        Debug.Log("ened");
    }
    public void tojs()
    {
        string data=JsonUtility.ToJson(upv);
        File.WriteAllText(path, data);
    }
    public void tocl()
    {
        if (File.Exists(path))
        {
            string rdata = File.ReadAllText(path);
            upv = JsonUtility.FromJson<UPG_values>(rdata);
        }
        else
        {
            Debug.Log("File Not Exists");
        }
    }

    /*public void Upgrade3()
        {
            upgradeinbut(3);
        }
public void Upgrade
        {
            upgradeinbut(2);
        }
        public void Upgrade
        {
            upgradeinbut(1);
        }
        public void Upgrade0()
        {
           upgradeinbut(0);
        }
    */
    public void upgradeinbut(int i)
    {

        Debug.Log(i);
        int amount = int.Parse(amount_text[i].text.ToString());
        if (coins >= amount)
        {
            if (barsize[i].localScale.x < .718f)
            {
                upsound.Play();
                resource.instance.Player.GetComponent<coins>().Totalcoins -= amount;
                Vector3 sc = barsize[i].localScale;
                sc.x += 0.1795f;
                barsize[i].localScale = sc;
                amount += 500;
                if (amount > 2000)
                {
                    amount_text[i].enabled = false;
                    Upgrade[i].gameObject.SetActive(false);
                }
                amount_text[i].text = amount.ToString();
                if (pickups[i].transform.name.Contains("Coin2"))
                {
                    pickups[i].GetComponent<coinmultiplier>().t += 2.5f;
                   upv.time[i]+=2.5f ;

                }
                else if (pickups[i].transform.name.Contains("Magnet"))
                {
                    pickups[i].GetComponent<pickupmagnet>().t += 2.5f;
                    upv.time[i] += 2.5f;
                }
                else if (pickups[i].transform.name.Contains("Boot"))
                {
                    pickups[i].transform.GetChild(0).GetComponent<boot>().t += 2.5f;
                    upv.time[i] += 2.5f;
                }
                else if (pickups[i].transform.name.Contains("Potion"))
                {
                    pickups[i].transform.GetChild(0).GetComponent<potion>().t += 2.5f;
                    upv.time[i] += 2.5f;
                }
                else
                {
                    Debug.Log("Error" + pickups[i].transform.GetChild(0).name);
                }
                upv.amount[i] = amount;
                upv.barValue[i] = sc.x;
                Total_coins_score.instance.SaveCoins();
                tojs();
            }
        }

    }
    public void cstoBarUPdate()
    {
        for (int i = 0; i <= 3; i++)
        {
            Vector3 sc = barsize[i].localScale;
            sc.x += upv.barValue[i];
            barsize[i].localScale = sc;
            amount_text[i].text = upv.amount[i].ToString();
            int amount = int.Parse(amount_text[i].text.ToString());
            if (amount > 2000)
            {
                amount_text[i].enabled = false;
                Upgrade[i].gameObject.SetActive(false);
            }
        }
    }
}


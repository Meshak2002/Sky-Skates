using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class time : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> activepickups;
    public bool upcomingpk;
    public UPG_values upv;
    public List<GameObject> forTimeset;
    public static time instance;

    private void OnEnable()
    {
        tocl();
            forTimeset[0].GetComponent<coinmultiplier>().t = upv.time[0];
            forTimeset[1].GetComponent<pickupmagnet>().t = upv.time[1];
            forTimeset[2].transform.GetChild(0).GetComponent<boot>().t = upv.time[2];
            forTimeset[3].transform.GetChild(0).GetComponent<potion>().t = upv.time[3];
    }
    public void tocl()
    {
        string path = Application.persistentDataPath + "UpgradeData.json";
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
                            }else if (activepickups[i].transform.Find("small health poti.003") != null)
                            {
                                Debug.Log("yae");
                                activepickups[i].transform.Find("small health poti.003").GetComponent<MeshRenderer>().enabled = upcomingpk;
                                activepickups[i].transform.Find("small health poti.003").GetComponent<CapsuleCollider>().enabled = upcomingpk;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color_change : MonoBehaviour
{
    // Start is called before the first frame update
    public Material dark, lit;
    public Material[] obstacleM;
    public string[] oc, cc;
    public Text[] txt;
    public Image img;
    private Color c;

    public static color_change instance;
    void Start()
    {
        if (instance == null)
            instance = this;
        ocolorChange();
    }
    public void ocolorChange()
    {
        RenderSettings.skybox = lit;
        for (int i = 0; i < oc.Length; i++)
        {
            if (ColorUtility.TryParseHtmlString("#" + oc[i], out c))
            {
                obstacleM[i].color = c;
            }
        }
        for(int i = 0; i < txt.Length; i++)
        {
            if(ColorUtility.TryParseHtmlString("#323232",out c))
            {
                txt[i].color = c;
            }
        }
        img.color = Color.white;
    }
    public void ccolorchange()
    {
        RenderSettings.skybox = dark;
        for (int i = 0; i < oc.Length; i++)
        {
            if (ColorUtility.TryParseHtmlString("#" + cc[i], out c))
            {
                obstacleM[i].color = c;
            }
        }
        for (int i = 0; i < txt.Length; i++)
        {
            if (ColorUtility.TryParseHtmlString("#73FFF9", out c))
            {
                txt[i].color = c;
                Debug.Log("asfaskjdan");
            }
        }
        img.color = Color.black;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void portalcolide()
    {
        GameObject tmp1, tmp2, tmp3;
        resource.instance.Player.SetActive(false);
        Debug.Log("Changed");
        resource.instance.splayer.transform.position = resource.instance.Player.transform.position;
        resource.instance.splayer.transform.rotation = resource.instance.Player.transform.rotation;
        resource.instance.splayer.SetActive(true);
        tmp1 = resource.instance.Player;
        tmp2 = resource.instance.camer;
        tmp3 = resource.instance.tarcam;
        resource.instance.Player = resource.instance.splayer;
        resource.instance.camer = resource.instance.scam;
        resource.instance.tarcam = resource.instance.starcam;
        resource.instance.splayer = tmp1;
        resource.instance.scam = tmp2;
        resource.instance.starcam = tmp3;
        if (RenderSettings.skybox == dark)
        {
            ocolorChange();
        }
        else
        {
            ccolorchange();
        }
       
    }
}

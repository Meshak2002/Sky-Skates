using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class color_change : MonoBehaviour
{
    // Start is called before the first frame update
    public Material dark, lit;
    public Material[] obstacleM,tr;
    public string[] oc, cc;
    public Text[] txt;
    public Image img;
    private Color c;
    public Volume vol;
    public Color p1, _p1, p2, _p2;

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
                tr[i].color = c;
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
                tr[i].color = c;
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
        SplitToning t;
        if(vol.profile.TryGet<SplitToning>(out t))
        {
            Debug.Log("CHHH");
            t.shadows.value=p2;
            t.highlights.value = _p2;
            p2 = p1;
            _p2 = _p1;
            p1 = t.shadows.value;
            _p1 = t.highlights.value;
        }
        
        GameObject tmp1, tmp2, tmp3;
        resource.instance.splayer.GetComponent<PlayerMovement>().forwardM = resource.instance.Player.GetComponent<PlayerMovement>().forwardM;
        resource.instance.splayer.GetComponent<PlayerMovement>().Movespeed = resource.instance.Player.GetComponent<PlayerMovement>().Movespeed;
        resource.instance.splayer.GetComponent<coins>().coin = resource.instance.Player.GetComponent<coins>().coin;
        resource.instance.splayer.GetComponent<coins>().Totalcoins = resource.instance.Player.GetComponent<coins>().Totalcoins;
        resource.instance.splayer.GetComponent<Score>().score = resource.instance.Player.GetComponent<Score>().score;
        resource.instance.splayer.GetComponent<Score>().hiscore = resource.instance.Player.GetComponent<Score>().hiscore;
        resource.instance.splayer.GetComponent<Score>().twohund = resource.instance.Player.GetComponent<Score>().twohund;
        resource.instance.splayer.GetComponent<Score>().forty = resource.instance.Player.GetComponent<Score>().forty;
        resource.instance.splayer.GetComponent<Score>().points = resource.instance.Player.GetComponent<Score>().points;

        resource.instance.Player.SetActive(false);
        Debug.Log("Changed");
        resource.instance.splayer.transform.position = resource.instance.Player.transform.position;
        resource.instance.splayer.transform.rotation = resource.instance.Player.transform.rotation;
        resource.instance.splayer.SetActive(true);

        tmp1 = resource.instance.Player;    //Swapping Process
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
        resource.instance.spawntile.GetComponent<spawnTile>().hero = resource.instance.Player;
        resource.instance.spawntile.GetComponent<spawnTile>().player = resource.instance.Player.transform;
    }
}

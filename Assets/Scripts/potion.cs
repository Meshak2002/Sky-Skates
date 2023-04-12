using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class potion : MonoBehaviour
{
    public GameObject img, bar, player, playerr,tmp;
    [HideInInspector] public float t, x = 0;
    public float tt;
    public time tim;
    public bool go;
    public Sprite logo;
    public Image holder;
    public static potion instance;
    public List<GameObject> obs;
    public Obst_MAterial om;
    public List<Material> cmaterials;
    public bool transparentb, visible;
    private Color a;
   private Material[] materials;
    public List<GameObject> obst;
    private  float duration=1, start;
    public AudioClip pickupSound;
    public void visiblee()
    {
        start = Time.time;
        visible = true;
    }
    public void invisible()
    {
        foreach(Material m in om.tramat)
        {
            Color a = m.color;
            a.a = 255;
            m.color =a;
        }
        foreach(GameObject G in resource.instance.spawntile.GetComponent<spawnTile>().glist)
        {
            Debug.Log(G.transform.Find("Obstacles").name);
            obs.Add(G.transform.Find("Obstacles").gameObject);
        }
       
        foreach (GameObject G in obs)
        {
            
            for(int i = 0; i < G.transform.childCount; i++)
            {
                obst.Add(G.transform.GetChild(i).gameObject);
            }
        }
        foreach (GameObject O in obst)
        {
            getMaterials(O);
        }

    }
    public void getMaterials(GameObject g)
    {
        if (g.gameObject.GetComponent<MeshCollider>())
        {
            g.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
        else if (g.gameObject.GetComponent<BoxCollider>())
        {
            g.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        materials = g.gameObject.GetComponent<Renderer>().sharedMaterials;
        foreach (Material m in materials)
        {
            Material n = m;
            for (int i = 0; i < om.mat.Count; i++)
            {
                if (n == om.mat[i])
                {
                    cmaterials.Add(om.tramat[i]);
                }
            }
        }
        g.gameObject.GetComponent<Renderer>().sharedMaterials = cmaterials.ToArray();
        cmaterials.Clear();
        start = Time.time;
        transparentb = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        holder = pausebutton.pb.hl;
        playerr = resource.instance.Player;
        tim = resource.instance.pickupmanager.GetComponent<time>();
        x = 1;
        tt = t;
    }
    private void Update()
    {
        if (transparentb == true)
        {
            float tim = Time.time - start;
            float alpha = Mathf.Lerp(1, 0, tim / duration);
            foreach (Material m in om.tramat)
            {
                    a = m.color;
                    a.a = alpha;
                    m.color = a;
            }
            if(alpha==0f)
                transparentb = false;
        }

        if (bar != null)
        {
            //bar.GetComponent<RectTransform>().localScale = new Vector3(3.709542f, 0.3380485f, 0.67292f);
        }

        if (visible == true)
        {
            float tim = Time.time - start;
            float alpha = Mathf.Lerp(0, 1, tim / duration);
            foreach (Material m in om.tramat)
            {
                a = m.color;
                a.a = alpha;
                m.color = a;
            }
            if (alpha == 1f)
            {
                foreach (GameObject O in obst)
                {
                    if (O != null)
                    {
                        if (O.gameObject.GetComponent<MeshCollider>())
                        {
                            O.gameObject.GetComponent<MeshCollider>().enabled = true;
                        }
                        else if (O.gameObject.GetComponent<BoxCollider>())
                        {
                            O.gameObject.GetComponent<BoxCollider>().enabled = true;
                        }

                        materials = O.gameObject.GetComponent<Renderer>().sharedMaterials;
                        foreach (Material m in materials)
                        {
                            Material n = m;
                            for (int i = 0; i < om.mat.Count; i++)
                            {
                                if (n == om.tramat[i])
                                {
                                    cmaterials.Add(om.mat[i]);
                                }
                            }
                        }
                        O.gameObject.GetComponent<Renderer>().sharedMaterials = cmaterials.ToArray();
                        cmaterials.Clear();
                    }
                }
                visible = false;
                Destroy(this.gameObject);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (resource.instance.pickupmanager.transform.childCount != 0)
            {
                foreach (Transform t in resource.instance.pickupmanager.transform)
                {
                    if (t.TryGetComponent<coinmultiplier>(out coinmultiplier cm))
                    {
                        cm.endthis();
                    }
                    else if (t.TryGetComponent<pickupmagnet>(out pickupmagnet pm))
                    {
                        pm.endthis();
                    }
                    else if (t.TryGetComponent<boot>(out boot b))
                    {
                        b.endthis();
                    }
                    else if (t.TryGetComponent<potion>(out potion p))
                    {
                        p.endpotion();
                    }
                }
            }
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            this.transform.SetParent(resource.instance.pickupmanager.transform);
            
            player = other.gameObject;
            this.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wai());
        }
    }
    public void FixedUpdate()
    {
        if (resource.instance.sccanvas != null)
        {
            bar = resource.instance.sccanvas.transform.GetChild(0).gameObject;
            img = bar.transform.GetChild(0).gameObject;
        }
        if (go == true && x > 0)
        {
            img.GetComponent<RectTransform>().localScale = new Vector3(x, 1, 1);
            x -= 1.0f / t * Time.deltaTime;
        }
        else
        {
            x = 1;
        }
    }
    IEnumerator wai()
    {
        invisible();
        bar.SetActive(true);
        holder.sprite = logo;
        //player.GetComponent<PlayerMovement>().JumpSpeed = 11;
        go = true;
        tim.upcomingpk = false;
        tim.hideunhi();
        Debug.Log("Time:"+ t);
        yield return new WaitForSeconds(t);
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        //player.GetComponent<PlayerMovement>().JumpSpeed = 6;
        visiblee();
        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        //Destroy(this.gameObject);
        tim.hideunhi();
    }
    public void endthis()
    {
        duration = .5f;
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        //player.GetComponent<PlayerMovement>().JumpSpeed = 6;
        transparentb = false;
        visiblee();
        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        //Destroy(this.gameObject);
        tim.hideunhi();
    }
    public void endpotion()
    {
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        transparentb = false;
        foreach (GameObject O in obst)
        {
            if (O != null)
            {
                if (O.gameObject.GetComponent<MeshCollider>())
                {
                    O.gameObject.GetComponent<MeshCollider>().enabled = true;
                }
                else if (O.gameObject.GetComponent<BoxCollider>())
                {
                    O.gameObject.GetComponent<BoxCollider>().enabled = true;
                }

                materials = O.gameObject.GetComponent<Renderer>().sharedMaterials;
                foreach (Material m in materials)
                {
                    Material n = m;
                    for (int i = 0; i < om.mat.Count; i++)
                    {
                        if (n == om.tramat[i])
                        {
                            cmaterials.Add(om.mat[i]);
                        }
                    }
                }
                O.gameObject.GetComponent<Renderer>().sharedMaterials = cmaterials.ToArray();
                cmaterials.Clear();
            }
        }
        visible = false;
        //Destroy(this.gameObject);
        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
}

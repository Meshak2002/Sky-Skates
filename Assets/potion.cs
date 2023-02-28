using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class potion : MonoBehaviour
{
    public GameObject img, bar, player, playerr;
    public float t = 10, x = 0;
    public time tim;
    public bool go;
    public Sprite logo;
    public Image holder;
    public static potion instance;
    public List<GameObject> obs;
    public Obst_MAterial om;

    public void invisible()
    {
        
        foreach(GameObject G in resource.instance.spawntile.GetComponent<spawnTile>().tile)
        {
            Debug.Log(G.transform.Find("Obstacles").name);
            obs.Add(G.transform.Find("Obstacles").gameObject);
        }
        Material[] materials;
        foreach (GameObject G in obs)
        {
            foreach(Transform child in G.transform)
            {
                Debug.Log(child.gameObject);
                if (child.gameObject.GetComponent<MeshCollider>()) 
                { 
                    child.gameObject.GetComponent<MeshCollider>().enabled = false; 
                }
                else if (child.gameObject.GetComponent<BoxCollider>())
                {
                    child.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                materials = child.gameObject.GetComponent<Renderer>().sharedMaterials;
                foreach (Material m in materials)
                {
                    Material n = m;
                    for(int i = 0; i < om.mat.Count; i++)
                    {
                        if (n == om.mat[i])
                        {
                            
                        }
                    }
                        
                }
                    /*materials = child.gameObject.GetComponent<Renderer>().sharedMaterials;
                    foreach (Material m in materials)
                    {
                        Material n=m;
                        if(!om.mat.Contains(n))
                            om.mat.Add(n);
                    }*/
                }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        /*holder = pausebutton.pb.hl;
        playerr = resource.instance.Player;
        tim = GameObject.Find("Pickup Manager").GetComponent<time>();
        x = 1;*/
        invisible();
    }
    private void Update()
    {
        if (bar != null)
        {
            bar.GetComponent<RectTransform>().localScale = new Vector3(3.709542f, 0.3380485f, 0.67292f);
        }
        /*if (playerr.transform.CompareTag("PDead"))
        {
            Destroy(this.gameObject);
        }*/
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.SetParent(GameObject.Find("Pickup Manager").transform);
            player = other.gameObject;
            this.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(wai());
        }
    }
    public void FixedUpdate()
    {
        if (GameObject.Find("Score & coin canvas +pasue") != null)
        {
            bar = GameObject.Find("Score & coin canvas +pasue").transform.GetChild(0).gameObject;
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

        bar.SetActive(true);
        holder.sprite = logo;
        player.GetComponent<PlayerMovement>().JumpSpeed = 11;
        go = true;
        tim.upcomingpk = false;
        tim.hideunhi();
        yield return new WaitForSeconds(t);
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        player.GetComponent<PlayerMovement>().JumpSpeed = 6;

        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
    public void endthis()
    {
        tim.upcomingpk = true;
        tim.hideunhi();
        go = false;
        player.GetComponent<PlayerMovement>().JumpSpeed = 6;

        bar.SetActive(false);
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        tim.activepickups.Remove(this.gameObject);
        Destroy(this.gameObject);
        tim.hideunhi();
    }
}

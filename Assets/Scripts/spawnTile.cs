using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTile : MonoBehaviour
{
    public GameObject[] tile;
    // Start is called before the first frame update 
    public float currentx=+120.4f; //Starts spawning from 2nd Tile ,!st tile is default tile
    public float currenty=-16f;
    public float currentz=-3.32f;
    public float dimx=+120.4f;
    public float dimy=-16f;
    public float dimz=-3.32f;
    public GameObject hero;
    public GameObject Gameover;
    public Transform player;
    private int ran_dom;
    public List<GameObject> glist= new List<GameObject>();
    public GameObject csp_ui; //coin,score,pause canvas
    public AudioSource loopsound;

    private void Start()
    {
        hero = resource.instance.Player;
        player = resource.instance.Player.transform;
        SpawnTile(0);
        SpawnTile(1);
}

    // Update is called once per frame
    private void Update()
    {
        if(player.position.x>currentx-dimx-60.2f){
            ran_dom=Random.Range(0,tile.Length);
            SpawnTile(ran_dom);
            DeleteTitle();
        }
        if(hero.transform.position.y<currenty){ //FlyDie
            hero.transform.tag = "PDead";
            loopsound.Stop();
            hero.GetComponent<Animator>().enabled=false;
            hero.GetComponent<PlayerMovement>().enabled=false;
            hero.GetComponent<Score>().enabled=false;
            Gameover.SetActive(true);
            csp_ui.SetActive(false);
            
        }
    }
    private void SpawnTile(int t){
          GameObject Go = Instantiate(tile[t],new Vector3(currentx,currenty,currentz),Quaternion.Euler(0,0,-7.5f));
          glist.Add(Go);
          currentx+=dimx;
          currenty+=dimy;
          currentz+=dimz;
    }
    private void DeleteTitle(){
          Destroy(glist[0]);
          glist.RemoveAt(0);
    }
}

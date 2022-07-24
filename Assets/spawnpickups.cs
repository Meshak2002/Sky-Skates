using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpickups : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> pickups;
    public List<GameObject> spawn;
    public GameObject neu;
    public int rx, ry;
    public time tim;
    //public bool y;
    void Start()
    {
        tim = GameObject.Find("Pickup Manager").GetComponent<time>();
        rx = Random.Range(0, pickups.Count);
        ry = Random.Range(0, spawn.Count);

        neu = Instantiate(pickups[rx], spawn[ry].transform.position, pickups[rx].transform.rotation);
        neu.transform.SetParent(this.gameObject.transform);
        tim.activepickups.Add(neu);
    }

    // Update is called once per frame
  
}

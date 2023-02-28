using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpickups : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> pickups;
    public List<Transform> spawn;
    public GameObject neu;
    public int rpickup, rposition;
    public time tim;
    //public bool y;
    void Start()
    {
        tim = resource.instance.pickupmanager.GetComponent<time>();
        rpickup = Random.Range(0, pickups.Count);
        rposition = Random.Range(0, spawn.Count);
        
        neu = Instantiate(pickups[rpickup], spawn[rposition].position, pickups[rpickup].transform.rotation);
        neu.transform.SetParent(this.gameObject.transform);
        tim.activepickups.Add(neu);
        Destroy(spawn[rposition].gameObject);

    }
}

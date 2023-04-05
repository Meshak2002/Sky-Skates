using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sound;
    public GameObject magnet;
    public void Awake()
    {
        this.transform.root.gameObject.GetComponent<spawnpickups>().spawn.Add(this.transform);
    }
    public void Update()
    {
        magnet = resource.instance.Player.transform.Find("Magnettt").gameObject;
    }
    public void OnTriggerEnter(Collider co){
        if(co.tag=="Player"){
            this.transform.root.gameObject.GetComponent<spawnpickups>().spawn.Remove(this.transform);
            AudioSource.PlayClipAtPoint(sound,transform.position);
            co.GetComponent<coins>().coin+=co.GetComponent<coins>().amount;
            co.GetComponent<coins>().Totalcoins+=co.GetComponent<coins>().amount;
            if (magnet!=null)
            {
                magnet.GetComponent<magnet>().cins.Remove(this.gameObject);

            }
            Destroy(gameObject);

        }

    }
}

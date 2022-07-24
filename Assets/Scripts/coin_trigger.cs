using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sound;
    public GameObject magnet;
    public void Update()
    {
        magnet = GameObject.Find("Magnettt");
    }
    public void OnTriggerEnter(Collider co){
        if(co.name=="Player"){
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunt : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(stunnt());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator stunnt()
    {
        player.gravity = 5;
        player.forwardM = player.forwardM * 2;
        player.moveV.y = 3;
        yield return new WaitForSeconds(0.5f);
        player.gravity = 15;
        player.forwardM = player.forwardM/2;
    }
}

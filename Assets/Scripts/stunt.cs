using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunt : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement player;
    public float tim, start;
    public bool smooth, high, once;
    private Vector3 jmplayr;
    void Start()
    {
        player = resource.instance.Player.GetComponent<PlayerMovement>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (once == false)
            {
                Debug.Log("Collided");

                stunnt();
                once = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (smooth == true)
        {
            tim = Time.time - start;
            jmplayr.y = .2F*(player.forwardM);
            player.CC.Move(jmplayr*Time.deltaTime);
            if (tim >= .0667f * player.forwardM)
            {
                smooth = false;
                player.forwardM = player.forwardM - 2f;
                high = true;
            }
        }
        if (high == true)
        {
            jmplayr.y = -.2F;
            player.CC.Move(jmplayr*Time.deltaTime);
            if (player.CC.isGrounded)
            {
                player.gravitylock = false;
                player.jmplock = false;
                high = false;
            }
        }
    }
    void stunnt()
    {
        player.moveV.x = 0;
        player.gravitylock = true;
        player.jmplock = true;
        player.forwardM = player.forwardM + 2f;
        start = Time.time;
        smooth = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optimize : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] emissionMats;
    public int fps;
    void Start()
    {
        Application.targetFrameRate = fps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

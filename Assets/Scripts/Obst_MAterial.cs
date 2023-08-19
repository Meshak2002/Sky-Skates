using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Obstacle_Materials",menuName ="SCriptableObject/ObMats",order =1)]
public class Obst_MAterial : ScriptableObject
{
    // Start is called before the first frame update
    public List<Material> mat,tramat;
}

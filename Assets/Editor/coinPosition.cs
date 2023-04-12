using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class coinPosition : EditorWindow
{
    // Start is called before the first frame update
    RaycastHit hit;
    private float dist;
    private float Targetdist = 1.325174f;
  
    public GameObject p4refab,Coins;
    private GameObject thes;
    public List<GameObject> surface;

    [MenuItem("Window/Coins Alignment")]
    public static void ShowWindow()
    {
        GetWindow<coinPosition>("COINS Alignment");
    }
    private void OnGUI()
    {
        //prefab = EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), true) as GameObject;
        Coins = EditorGUILayout.ObjectField("GameObject", Coins, typeof(GameObject), true) as GameObject;
        //surface = EditorGUILayout.ObjectField("List", surface, typeof(List<GameObject>), true) as List<GameObject>;
        if (GUILayout.Button("ALIGN"))
        {
            if (Coins != null) {
                ALIGNER();
            }
        }
    }
    void ALIGNER()
    {
     //   prefab = Selection.activeGameObject;
        foreach (Transform g in Coins.transform)
        {
            if (g.GetChild(0).Find("updated coin"))
            {
                Debug.Log("Found child 'updated coin' in gameobject: " + g.GetChild(0).name);
                //g.GetChild(0).GetChild(0).GetComponent<Animator>().enabled = false;
                thes = g.GetChild(0).gameObject;

                if (Physics.Raycast(thes.transform.position, -thes.transform.up, out hit))
                {
                    dist = hit.distance;
                    Debug.Log("RAY HITTed " + g.GetChild(0).name);
                    //Debug.Log(hit.collider.gameObject.name);
                    if (Targetdist != dist)
                    {
                        float add = Targetdist - dist;  // The value to be added to the position to get the target Distance
                        thes.transform.position = new Vector3(thes.transform.position.x, thes.transform.position.y + add, thes.transform.position.z);
                        Debug.Log("Position changed for gameobject: " + g.GetChild(0).name);
                    }

                }
                else
                {
                    Debug.Log("Raycast did not hit any object for gameobject: " + g.name);
                }
               // g.GetChild(0).GetChild(0).GetComponent<Animator>().enabled = true;
            }
            else
            {
                Debug.Log("Could not find child 'updated coin' in gameobject: " + g.GetChild(0).name);
            }
        }
        Debug.Log("Alignment complete for Coins gameobject.");
        // PrefabUtility.ApplyPrefabInstance(prefab, InteractionMode.UserAction);
    }
}

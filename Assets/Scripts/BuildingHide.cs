using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHide : MonoBehaviour
{

    public Transform playerTransform;
    private GameObject currentBuilding;
    private float distCalculate;

    Ray castRay;
    RaycastHit castHit;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        castRay = new Ray(Camera.main.transform.position, playerTransform.position - Camera.main.transform.position);

        distCalculate = Vector3.Distance(playerTransform.position,Camera.main.transform.position);

        if(Physics.Raycast(castRay,out castHit, distCalculate))
        {
            if (castHit.collider != null)
            {
                if (castHit.collider.CompareTag("Obstacles"))
                            currentBuilding = castHit.collider.gameObject;
                            Destroy(currentBuilding);
            }
        }
    }

}
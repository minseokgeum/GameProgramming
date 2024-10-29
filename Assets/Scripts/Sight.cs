using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, (int)objectsLayers);
        detectedObject = null;

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];

            Vector3 directionToController = Vector3.Normalize(collider.bounds.center - transform.position);
            float angleToCollier = Vector3.Angle(transform.forward, directionToController);

            if(angleToCollier < angle)
            {
                if(!Physics.Linecast(transform.position, collider.bounds.center, (int)obstaclesLayers))
                {
                    detectedObject = collider;
                    break;
                }
            }
        }
    }
}

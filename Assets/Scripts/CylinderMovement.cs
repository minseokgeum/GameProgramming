using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 globalZDirection = Vector3.forward; // (0, 0, 1)
        rb.AddForce(globalZDirection * speed, ForceMode.Force);
    }
}
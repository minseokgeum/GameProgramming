using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 3f;
    public float turnSpeed = 100f;
    private float timeToChangeDirection = 2f;
    private float changeTimer = 0;

    void Start()
    {

    }

    void Update()
    {
        changeTimer += Time.deltaTime;
        if (changeTimer > 0.5)
        {
            float randomRotation = Random.Range(-5f, 5f);
            transform.Rotate(0, randomRotation, 0);
            changeTimer = timeToChangeDirection;
        }
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
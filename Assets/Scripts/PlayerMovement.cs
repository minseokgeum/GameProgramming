using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed;
    public float rotationspeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.Q)) { transform.Translate(0, speed * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.E)) { transform.Translate(0, -speed * Time.deltaTime, 0); }


        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(0, mouseX * rotationspeed * Time.deltaTime, 0);

    }
}

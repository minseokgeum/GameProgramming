using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float rotationSpeed = 100f;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        RotateWithMouse();
        MoveCharacter();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Quaternion currentRotation = rb.rotation;

        Quaternion deltaRotation = Quaternion.Euler(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        rb.MoveRotation(currentRotation * deltaRotation);
    }

    void MoveCharacter()
    {

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;


        rb.AddForce(movement * moveSpeed, ForceMode.Force);
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            isGrounded = false;
        }
    }
}
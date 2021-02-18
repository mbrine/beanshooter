using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 2.0f;

    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;

    public Vector3 vel;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        isGrounded = controller.isGrounded;
        if(isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
                vel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            else
                vel.y = 0.0f;
        }
        else
        vel.y += gravity * Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed *Time.deltaTime);


        controller.Move(vel*Time.deltaTime);
    }
}

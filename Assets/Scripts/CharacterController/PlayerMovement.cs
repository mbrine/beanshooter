using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //public CharacterController controller;

    public Rigidbody rigidBody;

    public float speed = 0.0f;
    public float maxSpeed = 12;
    public float accel = 120.0f;
    public float airAccel = 1.0f;
    public float gravity = -9.8f;
    public float groundFriction = 1.0f;
    public float jumpHeight = 2.0f;

    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;

    public Vector3 hvel;
    public Vector3 vel;
    public bool isGrounded;
    public bool cIsGrounded;

    public InputAction moveInput;
    public InputAction jumpInput;

    public Vector3 input;

    private float maxSpeedSqr;
    private float _maxSpeed
    {
        get
        {
            return _maxSpeed;
        }

        set
        {
            _maxSpeed = value;
            maxSpeedSqr = _maxSpeed * _maxSpeed;
        }

    }
    private float _mSpeed;
    private bool isStayingOnGround = false;


    private void Start()
    {
        moveInput.Enable();
        jumpInput.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        //controller.
        //isGrounded = controller.isGrounded;
        RaycastHit rch = new RaycastHit();
        Ray ray = new Ray(groundCheck.position, -transform.up * (groundDist + Mathf.Epsilon));
        Debug.DrawRay(groundCheck.position, -transform.up * (groundDist + Mathf.Epsilon), Color.yellow);
        isGrounded = Physics.Raycast(ray,out rch, groundDist + Mathf.Epsilon);
        //cIsGrounded = controller.isGrounded;
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        Vector3 _moveInp = new Vector3(moveInput.ReadValue<Vector2>().x, 0.0f, moveInput.ReadValue<Vector2>().y);
        input.x = _moveInp.x;
        input.z = _moveInp.z;
        Vector3 rVel = new Vector3(0, rigidBody.velocity.y, 0);
        hvel = rigidBody.velocity;
        hvel.y = 0.0f;
        Vector3 moveDir = (transform.forward * _moveInp.z + transform.right * _moveInp.x);
        if (isGrounded)
        {
            //Jump Logic
            if (jumpInput.ReadValue<float>() > 0.01f)
                rVel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //else //if (controller.isGrounded)
                //vel.y = 0.0f;

            //hvel += accel * _moveInp * Time.deltaTime;
            //hvel += accel * _moveInp * Time.deltaTime;
            if (isStayingOnGround)
            {
                if (hvel.sqrMagnitude > maxSpeed * maxSpeed)
                {
                    hvel = Vector3.MoveTowards(hvel, hvel.normalized * maxSpeed, groundFriction + accel);
                }
                else
                {
                    hvel = Vector3.MoveTowards(hvel, Vector3.zero, groundFriction * Time.deltaTime);
                }
            }
            hvel = Vector3.MoveTowards(hvel, moveDir * maxSpeed, accel * Time.deltaTime);

            if (!(jumpInput.ReadValue<float>() > 0.01f))
                isStayingOnGround = true;

            //speed = hvel.magnitude;
            //speed += accel * _moveInp.magnitude;
            ////speed = Mathf.Lerp
            //if (speed > maxSpeed)
            //{
            //    speed = maxSpeed;
            //}
            //
            //hvel = Vector3.Lerp(Vector3.zero, (transform.forward * input.z + transform.right * input.x) * maxSpeed, speed/maxSpeed);
        }
        else
        {
            hvel += airAccel * moveDir * Time.deltaTime;
            hvel = Vector3.Lerp(hvel, moveDir * hvel.magnitude, airAccel * _moveInp.magnitude * Time.deltaTime);
            isStayingOnGround = false;
            vel.y += gravity * Time.deltaTime;
        }

        Vector3 move = transform.right * input.x + transform.forward * input.z;

        //GetComponent<Rigidbody>().velocity = Vector3.MoveTowards(GetComponent<Rigidbody>().velocity,vel + hvel, Time.deltaTime);
        rVel += hvel;
        rigidBody.velocity = rVel;
        


    }
}

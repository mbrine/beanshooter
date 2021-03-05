using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float speed = 0.0f;
    public float maxSpeed = 12;
    public float accel = 120.0f;
    public float airAccel = 1.0f;
    public float gravity = -9.8f;
    public float groundFriction = 1.0f;
    public float jumpHeight = 2.0f;
    public float stepHeight = 2.0f;

    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;

    public Vector3 hvel;
    public Vector3 groundPos;
    public Vector3 vel;
    public Vector3 lateVel;
    public bool isGrounded;
    public bool cIsGrounded;
    public GameObject floorObject;

    public InputAction moveInput;
    public InputAction jumpInput;
    public Text speedText;

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
        RaycastHit rch = new RaycastHit();
        Ray ray = new Ray(groundCheck.position, -transform.up * (groundDist + Mathf.Epsilon));
        Debug.DrawRay(groundCheck.position, -transform.up * (groundDist + Mathf.Epsilon), Color.yellow);
        isGrounded = Physics.Raycast(ray, out rch, groundDist + Mathf.Epsilon);
        Vector3 _moveInp = new Vector3(moveInput.ReadValue<Vector2>().x, 0.0f, moveInput.ReadValue<Vector2>().y);
        input.x = _moveInp.x;
        input.z = _moveInp.z;
        Vector3 rVel = new Vector3(0, rigidBody.velocity.y, 0);
        hvel = rigidBody.velocity;
        speed = hvel.magnitude;
        hvel.y = 0.0f;
        Vector3 moveDir = (transform.forward * _moveInp.z + transform.right * _moveInp.x);
        Vector3 hMoveDir = moveDir;
        if (hMoveDir == Vector3.zero)
            hMoveDir = hvel.normalized;

        if (isGrounded)
        {
            floorObject = rch.collider.gameObject;
            groundPos = rch.point;
            //Jump Logic
            if (jumpInput.ReadValue<float>() > 0.01f)
                rVel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("MD:" + moveDir);
            if (isStayingOnGround)
            {
                if (hvel.sqrMagnitude > maxSpeed * maxSpeed)
                {
                    hvel = Vector3.MoveTowards(hvel, hvel.normalized * maxSpeed, groundFriction + accel*groundFriction);
                }
                else
                {
                    hvel = Vector3.MoveTowards(hvel, Vector3.zero, groundFriction * Time.deltaTime);
                }
            }
            hvel = Vector3.MoveTowards(hvel, hMoveDir * maxSpeed, accel * moveDir.magnitude * Time.deltaTime);

            if (!(jumpInput.ReadValue<float>() > 0.01f))
                isStayingOnGround = true;
        }
        else
        {
            hvel += airAccel * moveDir * Time.deltaTime;
            hvel = Vector3.Lerp(hvel, moveDir * hvel.magnitude, airAccel * _moveInp.magnitude * Time.deltaTime);
            isStayingOnGround = false;
            vel.y += gravity * Time.deltaTime;
        }

        Vector3 move = transform.right * input.x + transform.forward * input.z;

        rVel += hvel;
        rigidBody.velocity = rVel;

        speedText.text = "SPEED:"+ rigidBody.velocity.magnitude.ToString();
    }
    void LateUpdate()
    {
        lateVel = rigidBody.velocity;
        cIsGrounded = false;
    }

    void AttemptStep(Collision collision)
    {
        if (!isGrounded)
            return;

        if (collision.GetContact(collision.contactCount-1).normal.y > 0.3f)
        {
            cIsGrounded = true;
            floorObject = collision.gameObject;
            Debug.Log("CHANGED FLOOR: " + collision.gameObject);
        }

        if (isGrounded && collision.gameObject != floorObject)
        {
            Vector3 rayPos = transform.position + (collision.GetContact(collision.contactCount-1).point - transform.position).normalized * 1.01f;
            rayPos.y = transform.position.y;
            Ray stepRay = new Ray(rayPos + Vector3.up * 1.0f, Vector3.down);
            float rayDist = 2.0f;
            Debug.DrawLine(stepRay.origin, stepRay.origin + stepRay.direction * rayDist, Color.yellow, 3.0f);
            RaycastHit stepHit = new RaycastHit();
            if (Physics.Raycast(stepRay, out stepHit, rayDist))
            {
                if (stepHit.collider.gameObject == floorObject)
                    return;
                float height = rayDist - stepHit.distance;
                if (height < stepHeight)
                {
                    transform.position += Vector3.up * height;
                    transform.position = stepHit.point + Vector3.up * 1.0f;
                    rigidBody.velocity = lateVel;
                    floorObject = collision.gameObject;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        AttemptStep(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        AttemptStep(collision);
    }
}

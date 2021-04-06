using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rigidBody;

    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;

    public Vector3 hVel;
    public Vector3 groundPos;
    public Vector3 vel;
    public Vector3 lateVel;
    public RaycastHit rch;
    public bool isGrounded;
    public bool cIsGrounded;
    public GameObject floorObject;


    public float speed = 0.0f;
    public float maxSpeed = 12;
    public float accel = 120.0f;
    public float airAccel = 1.0f;
    public float gravity = -9.8f;
    public float groundFriction = 1.0f;
    public float jumpHeight = 2.0f;
    public float stepHeight = 2.0f;
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

    public void Move(Vector3 dir, bool jump)
    {
        Vector3 rVel = new Vector3(0, rigidBody.velocity.y, 0);
        hVel = rigidBody.velocity;
        speed = hVel.magnitude;
        hVel.y = 0.0f;
        Vector3 moveDir = (transform.forward * dir.z + transform.right * dir.x);
        Vector3 hMoveDir = moveDir;
        if (hMoveDir == Vector3.zero)
            hMoveDir = hVel.normalized;

        if (isGrounded)
        {
            floorObject = rch.collider.gameObject;
            groundPos = rch.point;
            //Jump Logic
            if (jump)
            {
                rVel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                //hvel += moveDir * airAccel;
                isStayingOnGround = false;
            }
            Debug.Log("MD:" + moveDir);
            hVel = Vector3.MoveTowards(hVel, hMoveDir * maxSpeed, accel * moveDir.magnitude * Time.deltaTime);

            //if (!jump)
            //    isStayingOnGround = true;
        }
        else
        {
            hVel += airAccel * moveDir * Time.deltaTime;
            hVel = Vector3.MoveTowards(hVel, moveDir * hVel.magnitude, airAccel * dir.magnitude * Time.deltaTime * 100);
            //isStayingOnGround = false;
            vel.y += gravity * Time.deltaTime;
        }


        rVel += hVel;
        rigidBody.velocity = rVel;

    }
    public void Jump()
    {
        Vector3 rVel = new Vector3(0, rigidBody.velocity.y, 0);
        if (isGrounded)
        {
                rVel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                //hvel += moveDir * airAccel;
                isStayingOnGround = false;
        }
        else
        {
            return;
        }
        rVel += hVel;
        rigidBody.velocity = rVel;
    }

    void AttemptStep(Collision collision)
    {
        if (!isGrounded)
            return;
        //if (collision.gameObject == floorObject)
        //    return;
        if (collision.GetContact(collision.contactCount - 1).normal.y > 0.9f)
        {
            cIsGrounded = true;
            floorObject = collision.gameObject;
            Debug.Log("CHANGED FLOOR: " + collision.gameObject);
        }
        //else
        //    return;
        Debug.Log(collision.GetContact(collision.contactCount - 1).normal);
        if (isGrounded && collision.gameObject != floorObject)
        {
            Vector3 collisionDir = transform.position + (collision.GetContact(collision.contactCount - 1).point - transform.position).normalized;
            Vector3 rayPos = collisionDir * 1.01f;
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
                    transform.position += Vector3.up * (height + 0.001f);
                    transform.position += collisionDir * 0.001f;
                    //transform.position = stepHit.point + Vector3.up * 1.0f;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(groundCheck.position, -transform.up * (groundDist + Mathf.Epsilon));
        Debug.DrawRay(groundCheck.position, -transform.up * (groundDist + Mathf.Epsilon), Color.yellow);
        isGrounded = Physics.Raycast(ray, out rch, groundDist + Mathf.Epsilon);
        Vector3 rVel = rigidBody.velocity;
        hVel = rVel;
        rVel.x = rVel.z = hVel.y = 0;
        if (isStayingOnGround)
        {
            if (hVel.sqrMagnitude > maxSpeed * maxSpeed)
            {
                hVel = Vector3.MoveTowards(hVel, hVel.normalized * maxSpeed, groundFriction + accel * groundFriction);
            }
            else
            {
                hVel = Vector3.MoveTowards(hVel, Vector3.zero, groundFriction * Time.deltaTime);
            }
        }
        rVel += hVel;
        rigidBody.velocity = rVel;
        isStayingOnGround = false;

    }
    void LateUpdate()
    {
        lateVel = rigidBody.velocity;
        cIsGrounded = false;
        isStayingOnGround = isGrounded;
    }

}

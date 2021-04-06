using System.Collections;
using System.Collections.Generic;
using BeanGame;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BeanGame.GamePlayerCharacter))]
public class PlayerMovement : MonoBehaviour
{
    public InputAction moveInput;
    public InputAction jumpInput;
    public Text speedText;

    public Vector3 input;

    private CharacterMovement _characterMovement;

    private void Start()
    {
        moveInput.Enable();
        jumpInput.Enable();

        _characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit rch = new RaycastHit();
        Vector3 _moveInp = new Vector3(moveInput.ReadValue<Vector2>().x, 0.0f, moveInput.ReadValue<Vector2>().y);
        input.x = _moveInp.x;
        input.z = _moveInp.z;
        _characterMovement.Move(_moveInp, (jumpInput.ReadValue<float>() > 0.01f));

        speedText.text = "SPEED:"+ _characterMovement.hVel.magnitude.ToString();
    }


    void AttemptStep(Collision collision)
    {
        if (!isGrounded)
            return;
        Debug.Log(collision.GetContact(collision.contactCount - 1).normal);
        if (collision.GetContact(collision.contactCount - 1).normal.y > 0.4f)
        {
            cIsGrounded = true;
            floorObject = collision.gameObject;
            Debug.Log("CHANGED FLOOR: " + collision.gameObject);
        }
        else
            return;

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

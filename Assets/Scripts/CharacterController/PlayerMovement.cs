using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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


}

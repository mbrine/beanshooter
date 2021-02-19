using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLookCamera : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    public float xRotation = 0f;

    public InputAction lookAction;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lookAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = lookAction.ReadValue<Vector2>().x * mouseSensitivity;
        float mouseY = lookAction.ReadValue<Vector2>().y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(mouseX * playerBody.up);
    }
}

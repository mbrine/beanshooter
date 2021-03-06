using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction fireAction;
    public BeanGame.Weapon weapon;

    public float yaw;
    public float pitch;

    // Start is called before the first frame update
    void Start()
    {
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        weapon.currentCycleTime -= Time.deltaTime;
        if (weapon.currentCycleTime <= 0.0f)
        {
            if (fireAction.ReadValue<float>() > 0.01f)
            {
                weapon.Fire(transform.position, transform.position, transform.forward, transform.up, transform.right);
            }
        }

    }
}

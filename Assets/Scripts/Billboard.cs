using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform camTransform;

    void Awake()
    {
        camTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt( camTransform.position );
    }
}

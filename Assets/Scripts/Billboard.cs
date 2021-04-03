using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] [Range(0f, 360f)] float _xOffset = 0f;
    [SerializeField] [Range(0f, 360f)] float _yOffset = 0f;
    [SerializeField] [Range(0f, 360f)] float _zOffset = 0f;

    Transform m_camera;

    void Awake()
    {
        m_camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt( m_camera.position );
        transform.rotation = Quaternion.Euler(_xOffset, _yOffset, _zOffset) * transform.rotation;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotateSpeed;
    public bool IsClockWise;
    private float _rotateZ;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (IsClockWise)
        {
            _rotateZ += Time.deltaTime * RotateSpeed;
        }
        else
        {
            _rotateZ += -Time.deltaTime * RotateSpeed;
        }
        
        _transform.rotation = Quaternion.Euler(0 , 0 , _rotateZ);
    }
}

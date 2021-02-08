using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Follow;
    public Vector2 Offset;
    public float RightBounds;

    private Transform _transform;


    private void Awake()
    {
        Follow = GameObject.Find("Player").transform;
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        var position = _transform.position;
        if(Follow != null)
         _transform.position = new Vector3(Follow.position.x+Offset.x,position.y+Offset.y,position.z);
        
        
        if(_transform.position.x >= RightBounds)
            _transform.position = new Vector3(RightBounds,position.y,position.z);
        if(_transform.position.x <= 2)
            _transform.position = new Vector3(2,position.y,position.z);
            
        
    }
}

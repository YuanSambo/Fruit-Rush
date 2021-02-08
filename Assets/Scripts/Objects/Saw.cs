using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
  
    public float Speed;
    public float Distance;
    
    private float _direction = 1;
    private Vector2 _startingPosition;
    private Rotator _rotator;

    private Transform _transform;


    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
        _transform = GetComponent<Transform>();
        _startingPosition = _transform.position;
    }

    private void Update()
    {
        _transform.position += new Vector3(Speed*Time.deltaTime*_direction,0);


        if (_transform.position.x >= Mathf.Abs(_startingPosition.x + Distance))
        {
            _direction = -1;
            _rotator.IsClockWise = true;
        }
        else if (_transform.position.x <= _startingPosition.x)
        {
            _direction = 1;
            _rotator.IsClockWise = false;

        }



    }
    
    private void MovePlatform()
    {

        
        
            
        
    }
}

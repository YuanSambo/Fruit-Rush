using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private float width;
    public float speed = 2f;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }


    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(-speed, 0);
        if (_transform.position.x <= -_boxCollider2D.bounds.extents.x)
        {
            _transform.position = new Vector3(0, _transform.position.y);
        }
    }
}
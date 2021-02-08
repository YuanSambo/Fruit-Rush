using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Invoke("DropPlatform",0.5f);
        }
    }

    private void DropPlatform()
    {
        _animator.SetBool("IsOff",true);
        _rigidbody.isKinematic = false;
        Destroy(gameObject,2f);
    }
} 

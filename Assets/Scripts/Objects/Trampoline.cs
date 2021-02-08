using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float Force;

    private Animator _animator;
    private float Timer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var playerController = other.gameObject.GetComponent<PlayerController>();
        var player = other.gameObject.GetComponent<Player>();
        var defaultJumpForce = player.JumpForce;
        if (player != null)
        {
            player.JumpForce = Force;
            if (Timer >= 1f)
            {
                playerController.Jump();
                _animator.SetTrigger("Jump Off");
                Timer = 0;
            }
            
            player.JumpForce = defaultJumpForce;
        }
    }


   
}

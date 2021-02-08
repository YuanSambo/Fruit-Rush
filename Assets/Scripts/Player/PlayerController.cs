using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class PlayerController : MonoBehaviour
{

    #region Variables

   

    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private bool _doubleJumped;
    private float inputX;
    private BoxCollider2D _boxCollider2D;
    private bool Grounded;
    private Animator _animator;
    private Player _player;
    
    [Header("Ground Check")]
    public float GroundCheckHeight = .1f;
    public LayerMask GroundLayer;
    #endregion

    public ParticleSystem Dust;
    private bool _jump;
    private bool _doubleJump;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _player =GetComponent<Player>();
    }
    
    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        
        if (inputX < 0)
        {
            _transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (inputX > 0)
        {
            _transform.rotation = Quaternion.Euler(0,180,0);

        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
        {
            _jump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !_doubleJumped && !Grounded)
        {
            _doubleJump = true;
        }
        
        
        
        var main = Dust.main;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Dust.Play();
            main.loop = true;
        }
        else if ( Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            main.loop = false;
        }


        if (_transform.position.y <= -5f)
        {
            _player.Death();
        }
        
    }
    
    
    private void FixedUpdate()
    {
        Grounded = IsGrounded();

        if (_jump)
        {
            Jump();
            _jump = false;
        }

        if (_doubleJump)
        {
            DoubleJump();
            _doubleJump = false;
        }
        
        
        if (Grounded)
        {
            _animator.SetBool("isDoubleJumping",false);
            _animator.SetBool("isFalling",false);
            _doubleJumped = false;
        }
        
        
        // Better Jump
        if (_rigidbody.velocity.y < -1)
        {
            _animator.SetBool("isFalling",true);
            _animator.SetBool("isDoubleJumping",false);
            _rigidbody.velocity += Vector2.up * (Physics2D.gravity.y * (_player.FallMultiplier - 1) * Time.deltaTime);
        }


        MovePlayer();
        
    }
    public void Jump()
    {
        SoundManager.Instance.Play("Jump");
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,_player.JumpForce);
        _animator.SetTrigger("Jump");
    }
    private void DoubleJump()
    {
        _animator.SetBool("isDoubleJumping",true);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,_player.JumpForce);
        _doubleJumped = true;

    }

    private bool IsGrounded()
    {
        var bounds = _boxCollider2D.bounds;
        RaycastHit2D raycastHit = Physics2D.Raycast(bounds.center, Vector2.down, bounds.extents.y+GroundCheckHeight,GroundLayer);
        return raycastHit.collider!=null;
    }
    private void MovePlayer()
    {    
        _rigidbody.velocity = new Vector2(inputX * _player.MovementSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", _rigidbody.velocity.x);
        
    }

   
}

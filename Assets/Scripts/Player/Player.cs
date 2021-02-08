using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    #region Variables

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Animator _animator;
    private PlayerController _playerController;
    private float elapsedTime;
    
    [Header("Attributes")]
    public float MovementSpeed;
    public float JumpForce;
    public float FallMultiplier;
    #endregion

    public GameEvent IsPlayerDead;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        Invoke(nameof(ToggleMovement),1);
        if (!(Camera.main is null)) Camera.main.GetComponent<CameraController>().Follow = _transform;
    }
    

    public void Death()
    {
        IsPlayerDead.Raise();
        SoundManager.Instance.Play("Dead");
        ToggleMovement();
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger("Death");
        Destroy(gameObject,1);
    }

    public void ToggleMovement()
    {
        _playerController.enabled = !_playerController.enabled;
    }

   
   
}

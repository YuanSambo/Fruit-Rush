using System;
using UnityEngine;


    public class Collectibles : MonoBehaviour
    {
        private Animator _animator;
        private CircleCollider2D _circleCollider;
        public float Value;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
            _circleCollider = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _circleCollider.enabled = false;
            GameManager.Instance.FruityBar.Value += Value;
            SoundManager.Instance.Play("Collect");
            _animator.SetBool("isCollected",true);
            Destroy(gameObject,1f);
        }
    }

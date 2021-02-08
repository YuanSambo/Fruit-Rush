using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private GameObject _transition;
    private Animator _transitionAnimator;

    private void Awake()
    {
        _transition = GameObject.Find("Transition");
        _transitionAnimator = _transition.GetComponent<Animator>();
    }

    private void Start()
   {
       SoundManager.Instance.Play("Win");
       _transitionAnimator.SetTrigger("Ease In");
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
    
   }
}

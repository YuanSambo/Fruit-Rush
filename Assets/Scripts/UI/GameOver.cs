using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public GameObject[] Cursors;
   private Animator _animator;
   private Choice _isSelected = Choice.PlayAgain;
   private bool _isEnabled = false;

   private enum Choice
   {
      PlayAgain,
      Menu,
   }
   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }


   private void Update()
   {
      if (!_isEnabled) return;
      switch (_isSelected)
      {
         case Choice.PlayAgain:
            if (Input.GetKeyDown(KeyCode.Return))
            {
               SoundManager.Instance.Play("Choose");
               StartCoroutine(GameManager.Instance.PlayAgain());
            }
            break;
         case Choice.Menu:
            if (Input.GetKeyDown(KeyCode.Return))
            {
               SoundManager.Instance.Play("Choose");
               StartCoroutine(GameManager.Instance.MainMenu());

            }
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }

      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
         _isSelected = Choice.PlayAgain;
         Cursors[0].SetActive(true);
         Cursors[1].SetActive(false);

      }else if (Input.GetKeyDown(KeyCode.DownArrow))
      {
         _isSelected = Choice.Menu;
         Cursors[0].SetActive(false);
         Cursors[1].SetActive(true);
      }


   }

   public void MoveDown()
   {
      _animator.SetTrigger("Move Down");
   }

   public void Enable()
   {
      _isEnabled = true;
   }
}

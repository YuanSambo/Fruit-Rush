using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   public List<GameObject> Cursors;
   public List<GameObject> Panels;
   private Image _start;
   private Image _howTo;
   private Choices _selected = Choices.Start;

   #region Transitions
   private GameObject _transition;
   private Animator _transitionAnimator;
   #endregion

   
   
   private enum Choices
   {
       Start,
       HowToPlay,
       Back,
   }


   private void Awake()
   {
       _transition = GameObject.Find("Transition");
       _transitionAnimator = _transition.GetComponent<Animator>();
   }

   private void Start()
   {
       _transitionAnimator.SetTrigger("Ease In");
      _start = Cursors[0].GetComponent<Image>();
      _howTo = Cursors[1].GetComponent<Image>();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
        _start.enabled = true;
        _howTo.enabled = false;
        _selected = Choices.Start;
      }
      
      else if (Input.GetKeyDown(KeyCode.DownArrow))
      {
        _howTo.enabled = true;
        _start.enabled = false;
        _selected = Choices.HowToPlay;

      }

      switch (_selected)
      {
          case Choices.Start:
              if (Input.GetKeyDown(KeyCode.Return))
              {
                  SoundManager.Instance.Play("Choose");
                  StartCoroutine(ChangeScene());
                  
              }
              break;

          case Choices.HowToPlay:
             
              if (Input.GetKeyDown(KeyCode.Return))
              {
                  SoundManager.Instance.Play("Choose");
                  Panels[0].gameObject.SetActive(false);
                  Panels[1].gameObject.SetActive(true);
                  _selected = Choices.Back;

                  
              }
              break;

          case Choices.Back:
              if (Input.GetKeyDown(KeyCode.Return))
              {
                  SoundManager.Instance.Play("Choose");
                  Panels[0].gameObject.SetActive(true);
                  Panels[1].gameObject.SetActive(false);
                  _selected = Choices.HowToPlay;
              }

              break;
          default:
              throw new ArgumentOutOfRangeException();
      }
   }


   private IEnumerator ChangeScene()
   {    
       _transitionAnimator.SetTrigger("Ease Out");
       yield return new WaitForSeconds(0.9f);
       SceneManager.LoadScene(1);
   }
}

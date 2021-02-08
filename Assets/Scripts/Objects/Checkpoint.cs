using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
   private int currentScene;

   private void Awake()
   {
     currentScene = SceneManager.GetActiveScene().buildIndex;
     
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
       if (other.gameObject.tag.Equals("Player"))
       {
           GameManager.Instance.PauseTimer();
           StartCoroutine(GameManager.Instance.ChangeScene());

       }
   }

}

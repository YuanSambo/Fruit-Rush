using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
   void Awake()
   {
      GameObject[] _soundmManagers = GameObject.FindGameObjectsWithTag("SoundManager");

      if (_soundmManagers.Length > 1)
      {
         Destroy(this.gameObject);
      }
      
      DontDestroyOnLoad(this.gameObject);
   }
}

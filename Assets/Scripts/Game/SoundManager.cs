using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public Sound[] Sounds;
    private void Awake()
    {
        Instance = this;

        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }

        
    }

    public void Play(string name)
    {
        var sound = Array.Find(Sounds,sounds => sounds.Name == name);
        sound?.Source.Play();
    }
    
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class UIFruits : MonoBehaviour
{
    private Text _text;
    public FloatReference FruitBarTime;


    private void Awake()
    {
        _text = GetComponent<Text>();
    }


    private void Update()
    {
        _text.text = $"X {Math.Floor(FruitBarTime.Value)}";
    }
}

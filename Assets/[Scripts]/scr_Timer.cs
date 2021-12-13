/*
/* Sourcefile:      scr_Timer.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Updates the on-screen timer. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_Timer : MonoBehaviour
{
    public static float timerTime;
    public TextMeshProUGUI timerDisplay;


    void Start()
    {
        timerTime = 0;
        timerDisplay = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        timerTime += Time.deltaTime;
        int timeInInt = (int)timerTime;
        timerDisplay.text = timeInInt.ToString();
    }


}

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

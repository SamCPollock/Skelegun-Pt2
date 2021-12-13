/*
/* Sourcefile:      scr_WinScreen.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Sets the values on win screen score UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_WinScreen : MonoBehaviour
{
    public TextMeshProUGUI timeNumber;
    public TextMeshProUGUI shotsNumber;
    public TextMeshProUGUI reloadsNumber;
    public TextMeshProUGUI scoreNumber;



    void Start()
    {
        timeNumber.text = PlayerPrefs.GetInt("Time").ToString();
        shotsNumber.text = PlayerPrefs.GetInt("Shots").ToString();
        reloadsNumber.text = PlayerPrefs.GetInt("Reloads").ToString();

        scoreNumber.text = PlayerPrefs.GetInt("Score").ToString();

    }
}

/*
/* Sourcefile:      scr_Score.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Stores the player score.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class scr_Score : MonoBehaviour
{
    static public int score;
    static private TextMeshProUGUI scoreDisplay;
    static public int shotsTaken;
    static public int reloadsTaken;

    void Start()
    {
        scoreDisplay = gameObject.GetComponent<TextMeshProUGUI>();

    }

    /// <summary>
    ///  Static function to add score to the total. Is called by gameobjects with score values. 
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreDisplay.text = score.ToString();
    }
}

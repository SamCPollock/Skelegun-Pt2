/*
/* Sourcefile:      scr_Exit.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles leaving the gameplay scene and assigning score values in Playerprefs
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Exit : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndLevel();
        }

    }

    /// <summary>
    /// Leave the scene and assign playerprefs scores. 
    /// </summary>
    private void EndLevel()
    {
        SceneManager.LoadScene("scene_Win");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Score", scr_Score.score);
        PlayerPrefs.SetInt("Time", (int)scr_Timer.timerTime);
        PlayerPrefs.SetInt("Reloads", scr_Score.reloadsTaken);
        PlayerPrefs.SetInt("Shots", scr_Score.shotsTaken);




    }
}

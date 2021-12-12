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

    private void EndLevel()
    {
        SceneManager.LoadScene("scene_Win");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Score", scr_Score.score);
        PlayerPrefs.SetInt("Time", (int)scr_Timer.timerTime);
        PlayerPrefs.SetInt("Reloads", scr_Score.reloadsTaken);
        PlayerPrefs.SetInt("Shots", scr_Score.shotsTaken);



        //PlayerPrefs.GetInt(playerPrefKey).ToString();

    }
}

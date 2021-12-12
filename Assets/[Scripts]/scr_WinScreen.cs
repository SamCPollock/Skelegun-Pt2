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

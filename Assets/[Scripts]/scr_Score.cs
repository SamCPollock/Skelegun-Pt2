using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class scr_Score : MonoBehaviour
{
    static public int score;
    static private TextMeshProUGUI scoreDisplay;
    void Start()
    {
        scoreDisplay = gameObject.GetComponent<TextMeshProUGUI>();

    }

    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreDisplay.text = score.ToString();
    }
}

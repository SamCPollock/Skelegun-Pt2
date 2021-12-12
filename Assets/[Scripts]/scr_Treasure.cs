using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Treasure : MonoBehaviour
{
    public int scoreValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AwardScore();
        }
    }

    private void AwardScore()
    {
        scr_Score.AddScore(scoreValue);
        Destroy(gameObject);
    }
}

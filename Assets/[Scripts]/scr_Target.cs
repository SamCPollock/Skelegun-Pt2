using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Target : MonoBehaviour
{
    public int scoreValue; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<scr_Bullet>() != null)
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

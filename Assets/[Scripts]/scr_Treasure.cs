using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Treasure : MonoBehaviour
{
    public int scoreValue;
    public AudioClip addScoreSound;

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
        scr_SoundEffectsManager.PlaySoundEffect(addScoreSound, 1, scoreValue / 15f);
        Destroy(gameObject);
    }
}

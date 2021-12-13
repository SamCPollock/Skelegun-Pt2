/*
/* Sourcefile:      scr_Target.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles Target logic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Target : MonoBehaviour
{
    public int scoreValue;
    public AudioClip targetDestroyedSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<scr_Bullet>() != null)
        {
            AwardScore();
        }
    }




    /// <summary>
    /// Adds to score total
    /// </summary>
    private void AwardScore()
    {
        scr_Score.AddScore(scoreValue);
        scr_SoundEffectsManager.PlaySoundEffect(targetDestroyedSound);
        Destroy(gameObject);
    }
}

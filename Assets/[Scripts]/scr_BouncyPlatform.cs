/*
/* Sourcefile:      scr_BouncyPlatform.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles BouncyPlatform behaviours
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BouncyPlatform : MonoBehaviour
{
    public AudioClip bounceSound;


    /// <summary>
    /// /Play Bounce sound effect when player collides
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scr_SoundEffectsManager.PlaySoundEffect(bounceSound);
        }
    }
}

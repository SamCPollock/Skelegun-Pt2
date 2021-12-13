/*
/* Sourcefile:      scr_Bullet.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles bullet logic.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Bullet : MonoBehaviour
{
    public float lifespan;


    private float timeExisting = 0;
    public AudioClip hitSound;
    void Start()
    {
        
    }

    void Update()
    {
        // Check to see if bullet has existed past its predetermined lifespan. 
        timeExisting += Time.deltaTime;
        if (timeExisting >= lifespan)
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }


    /// <summary>
    /// Check for collision with enemy or terrain.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<scr_Ghost>() != null || collision.gameObject.GetComponent<scr_Zombie>() != null)
        {
            Destroy(collision.gameObject);
            scr_SoundEffectsManager.PlaySoundEffect(hitSound, 1, 0.5f);
            scr_Score.AddScore(10);
        }
        DestroyBullet();
    }
}

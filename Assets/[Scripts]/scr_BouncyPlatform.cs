using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BouncyPlatform : MonoBehaviour
{
    public AudioClip bounceSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scr_SoundEffectsManager.PlaySoundEffect(bounceSound);
        }
    }
}

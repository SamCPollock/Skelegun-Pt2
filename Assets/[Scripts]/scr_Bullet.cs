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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            scr_SoundEffectsManager.PlaySoundEffect(hitSound, 1, 0.5f);
            scr_Score.AddScore(10);
        }
        DestroyBullet();
    }
}

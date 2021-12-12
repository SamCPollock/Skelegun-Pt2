using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Ghost : MonoBehaviour
{

    public float moveSpeed;
    public float boostDelay;

    private float timeSinceLastBoost;
    private bool isFadedIn = true;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        FadeOut();
    }


    private void FixedUpdate()
    {
        timeSinceLastBoost += Time.deltaTime;
        if (timeSinceLastBoost >= boostDelay)
        {
            Boost();
        }
        rb.velocity *= 0.95f;


    }

    private void Boost()
    {
        rb.AddForce(new Vector3(Random.Range(-moveSpeed, moveSpeed), Random.Range(-moveSpeed, moveSpeed), 0f), ForceMode2D.Impulse);
        timeSinceLastBoost = 0;
    }



    void FadeIn()
    {
        gameObject.layer = 9;
        Color tempColor = spriteRenderer.color;
        tempColor.a = 1;
        spriteRenderer.color = tempColor;
        isFadedIn = true;
        Invoke("FadeOut", 3);
    }


    void FadeOut()
    {
        gameObject.layer = 7;
        isFadedIn = false;
        Color tempColor = spriteRenderer.color;
        tempColor.a = 0.1f;
        spriteRenderer.color = tempColor;
        Invoke("FadeIn", 2);
    }

   
}

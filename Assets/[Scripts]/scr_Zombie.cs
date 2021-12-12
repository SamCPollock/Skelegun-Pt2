using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Zombie : MonoBehaviour
{
    public float walkSpeed;

    public bool isGroundAhead;
    public Transform lookBelowPoint;
    public Transform lookAheadPoint;
    public LayerMask groundLayerMask;
    public LayerMask wallLayerMask;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        LookBelow();
        LookAhead();
        MoveEnemy();
    }

    private void LookBelow()
    {
        var hit = Physics2D.Linecast(transform.position, lookBelowPoint.position, groundLayerMask);
        isGroundAhead = (hit) ? true : false;
    }

    private void LookAhead()
    {
        var hit = Physics2D.Linecast(transform.position, lookAheadPoint.position, wallLayerMask);
        if (hit)
        {
            Flip();
        }
    }


    private void MoveEnemy()
    {
        if (isGroundAhead)
        {
            rb.AddForce(Vector2.left * walkSpeed * transform.localScale.x);
            rb.velocity *= 0.92f;
        }
        else
        {
            Flip();
        }
    }


    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }


}

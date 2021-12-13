/*
/* Sourcefile:      scr_Zombie.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles zombie enemy logic
 */
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
    /// <summary>
    /// Checks down to ensure the zombie is not going to step off a cliff
    /// </summary>
    private void LookBelow()
    {
        var hit = Physics2D.Linecast(transform.position, lookBelowPoint.position, groundLayerMask);
        isGroundAhead = (hit) ? true : false;
    }

    /// <summary>
    /// Check ahead to determine if the zombie is walking into a wall
    /// </summary>
    private void LookAhead()
    {
        var hit = Physics2D.Linecast(transform.position, lookAheadPoint.position, wallLayerMask);
        if (hit)
        {
            Flip();
        }
    }

    /// <summary>
    /// Walks forward according to walkSpeed
    /// </summary>
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

    /// <summary>
    /// Reverse facing direction.
    /// </summary>
    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }


}

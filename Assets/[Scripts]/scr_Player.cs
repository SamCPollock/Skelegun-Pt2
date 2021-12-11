using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f, 1.0f)]
    public float sensitivity;

    [Header("Movement")]
    public float maxSpeed;

    [Header("Gun Behaviour")]
    public float gunForce;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public float shotCooldown;


    private float nextFireTime;
    private bool isReloading = false;

    // References
    private GameObject gunPivot;
    private GameObject gun;
    private Rigidbody2D rb;




    void Start()
    {
        // Set references
        gunPivot = GameObject.Find("GunPivot");
        gun = GameObject.Find("GunSprite");
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Initialize variables
        nextFireTime = Time.time;
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            AimGun();
        }

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }

    }

    private void FixedUpdate()
    {
       // Debug.Log("Velocity = " + rb.velocity);
    }


    private void AimGun()
    {
        Vector2 aimDirection = joystick.Direction;
        float aimAngleRad = Mathf.Atan2(aimDirection.y, aimDirection.x);
        float aimAngleDeg = aimAngleRad * Mathf.Rad2Deg;

        gunPivot.transform.eulerAngles = new Vector3(0, 0, aimAngleDeg);
    }

    public void FireGun()
    {
        if (currentAmmo > 0 && !isReloading)
        {
            if (Time.time > nextFireTime)
            {
                rb.velocity = Vector2.zero;
                Vector2 directionVector = gameObject.transform.position - gun.transform.position;
                rb.AddForce(directionVector.normalized * gunForce);
                nextFireTime = Time.time + shotCooldown;
                currentAmmo--;
            }
        }
    }

    public void ReloadPressed()
    {
        if (!isReloading)
        {
            Invoke("UpdateAmmo", reloadTime);
            isReloading = true;
            Debug.Log("STARTING TO RELOAD");
        }
    }

    private void UpdateAmmo()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("RELOAD COMPLETE");

    }
}

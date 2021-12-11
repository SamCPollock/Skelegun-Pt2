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
    public float recoilForce;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public float shotCooldown;
    public float bulletForce;


    private float nextFireTime;
    private bool isReloading = false;



    // References
    public GameObject bulletPrefab;
    
    private GameObject gunPivot;
    private GameObject gun;
    private GameObject firePoint;
    private Rigidbody2D rb;
    private GameObject skeletonSprite;




    void Start()
    {
        // Set references
        gunPivot = GameObject.Find("GunPivot");
        gun = GameObject.Find("GunSprite");
        firePoint = GameObject.Find("FirePoint");
        rb = gameObject.GetComponent<Rigidbody2D>();
        skeletonSprite = GameObject.Find("SkeletonSprite");

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

        if (firePoint.transform.position.x < gameObject.transform.position.x)
        {
            skeletonSprite.transform.localScale = new Vector3(1, 1, 1);
            gun.transform.localScale = new Vector3(-1, -1, 1);
            
        }
        else
        {
            skeletonSprite.transform.localScale = new Vector3(-1, 1, 1);
            gun.transform.localScale = new Vector3(-1, 1, 1);

        }

        //if (gunPivot.transform.eulerAngles.z < -90 || gunPivot.transform.eulerAngles.z > 90)
        //{
        //    skeletonSprite.transform.localScale = new Vector3(-1, 1, 1);
        //}
        //else
        //{
        //    skeletonSprite.transform.localScale = new Vector3(1, 1, 1);
        //}
    }

    public void FireGun()
    {
        if (currentAmmo > 0 && !isReloading)
        {
            if (Time.time > nextFireTime)
            {
                rb.velocity = Vector2.zero;
                Vector2 directionVector = gameObject.transform.position - gun.transform.position;
                rb.AddForce(directionVector.normalized * recoilForce, ForceMode2D.Impulse);
                nextFireTime = Time.time + shotCooldown;
                currentAmmo--;

                GameObject newBullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.right * bulletForce, ForceMode2D.Impulse);
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

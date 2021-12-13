/*
/* Sourcefile:      scr_Player.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles player logic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_Player : MonoBehaviour
{
    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f, 1.0f)]
    public float sensitivity;

    [Header("Movement")]
    public float maxSpeed;
    public float lives;

    [Header("Gun Behaviour")]
    public float recoilForce;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public float shotCooldown;
    public float bulletForce;

    [Header("Sound Effects")]
    public AudioClip fireSound;
    public AudioClip emptyFireSound;
    public AudioClip reloadSound;
    public AudioClip landingSound;
    public AudioClip hitSound;

    private float nextFireTime;
    private bool isReloading = false;

    static public bool isMobile;



    // References
    public GameObject bulletPrefab;
    
    private GameObject gunPivot;
    private GameObject gun;
    private GameObject firePoint;
    private Rigidbody2D rb;
    private GameObject skeletonSprite;
    private GameObject ammoUI;
    private new GameObject[] ammoUIimages = new GameObject[6];
    //private GameObject reloadBar;
    private Animator animator;
    private GameObject spawnPoint;

    private Vector3 velocityBeforeCollision; 





    void Start()
    {
        // Set references
        gunPivot = GameObject.Find("GunPivot");
        gun = GameObject.Find("GunSprite");
        firePoint = GameObject.Find("FirePoint");
        rb = gameObject.GetComponent<Rigidbody2D>();
        skeletonSprite = GameObject.Find("SkeletonSprite");
        ammoUI = GameObject.Find("AmmoUI");
        //reloadBar = GameObject.Find("ReloadBarSlider");
        animator = gameObject.GetComponent<Animator>();
        spawnPoint = GameObject.Find("SpawnPoint");

        for (int i = 0; i < ammoUIimages.Length; i++)
        {
            ammoUIimages[i] = ammoUI.transform.GetChild(i).gameObject;
        }

        // Initialize variables
        nextFireTime = Time.time;
        currentAmmo = maxAmmo;
    }

    void Update()
    {

        if (isMobile)
        {
            // Touch screen controls 
            if (joystick.Horizontal != 0 && joystick.Vertical != 0)
            {
                AimGun();
            }

        }

        else
        {
            // Mouse controls
            AimGunMouse();
        }


        ManageMaxSpeed();

    }


    private void FixedUpdate()
    {
        // Store velocity before physics update, used for determining speed of collisions.
        velocityBeforeCollision = rb.velocity;

    }


    /// <summary>
    /// Aims the gun according to touchscreen input.
    /// </summary>
    private void AimGun()
    {
        Vector2 aimDirection = joystick.Direction;
        float aimAngleRad = Mathf.Atan2(aimDirection.y, aimDirection.x);
        float aimAngleDeg = aimAngleRad * Mathf.Rad2Deg;

        gunPivot.transform.eulerAngles = new Vector3(0, 0, aimAngleDeg);

        HandleFacingDirection();
    
    }
    /// <summary>
    /// Aims the gun using mouse position. 
    /// </summary>
    void AimGunMouse()
    {
        Vector2 aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float aimAngleRad = Mathf.Atan2(aimDirection.y, aimDirection.x);
        float aimAngleDeg = aimAngleRad * Mathf.Rad2Deg;

        gunPivot.transform.eulerAngles = new Vector3(0, 0, aimAngleDeg);

        HandleFacingDirection();

        if (Input.GetMouseButtonDown(0))
        {
            FireGun();
        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.R))
        {
            ReloadPressed();
        }

    }

    /// <summary>
    /// Fires a bullet and sends player flying with recoil.
    /// </summary>
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
                UpdateAmmoUI();
                scr_SoundEffectsManager.PlaySoundEffect(fireSound, 1);
                scr_Score.shotsTaken++;
            }
        }
        else
        {
            scr_SoundEffectsManager.PlaySoundEffect(emptyFireSound, 1);

        }
    }

    /// <summary>
    /// Start reloading
    /// </summary>
    public void ReloadPressed()
    {
        if (!isReloading)
        {
            Invoke("FillAmmo", reloadTime);
            isReloading = true;
            //Debug.Log("STARTING TO RELOAD");
            animator.SetBool("isReloading", true);
            scr_SoundEffectsManager.PlaySoundEffect(reloadSound, 1);
            scr_Score.reloadsTaken++;

        }

    }
    /// <summary>
    /// Finish reloading
    /// </summary>
    private void FillAmmo()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
        //Debug.Log("RELOAD COMPLETE");
        UpdateAmmoUI();
        animator.SetBool("isReloading", false);
    }
    /// <summary>
    /// Updates UI ammo display
    /// </summary>
    private void UpdateAmmoUI()
    {
        for (int i = 0; i < ammoUIimages.Length; i++)
        {
            if (i >= currentAmmo)
            {
                ammoUIimages[i].SetActive(false);
            }
            else
            {
                ammoUIimages[i].SetActive(true);

            }
        }
    }

    /// <summary>
    /// Ensure player is moving under max speed
    /// </summary>
    private void ManageMaxSpeed()
    {

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }
    }
    /// <summary>
    /// Face player towards aiming direction
    /// </summary>
    private void HandleFacingDirection()
    {
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /// Play landing "ding" sound, volume determined by falling speed. 
        if (collision.gameObject.CompareTag("Platforms") && velocityBeforeCollision.y < -1)
        {
            scr_SoundEffectsManager.PlaySoundEffect(landingSound, -velocityBeforeCollision.y / 10f);

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    /// <summary>
    ///  Lose lives or lose the game when hit by an enemy or spikes. 
    /// </summary>
    private void Die()
    {
        lives--;
        Destroy(GameObject.Find("LivesUI").transform.GetChild(0).gameObject);
        if (lives <= 0)
        {
            SceneManager.LoadScene("Scene_Lose");
        }
        else
        {
            scr_SoundEffectsManager.PlaySoundEffect(hitSound);
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }

}

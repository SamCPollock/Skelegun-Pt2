using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f, 1.0f)]
    public float sensitivity;

    private GameObject gunPivot;

    void Start()
    {
        gunPivot = GameObject.Find("GunPivot");
    }

    void Update()
    {
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
            AimGun();        
    }


    private void AimGun()
    {
        Vector2 aimDirection = joystick.Direction;
        float aimAngleRad = Mathf.Atan2(aimDirection.y, aimDirection.x);
        float aimAngleDeg = aimAngleRad * Mathf.Rad2Deg;

        gunPivot.transform.eulerAngles = new Vector3(0, 0, aimAngleDeg);

    }
}

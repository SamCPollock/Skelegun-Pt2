/*
/* Sourcefile:      scr_UIManager.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles controls depending on the platform.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_UIManager : MonoBehaviour
{
    public GameObject onScreenControls;

    void Start()
    {
        CheckPlatform();

    }


    /// <summary>
    /// Determines what platform the game is running on. 
    /// </summary>
    private void CheckPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                onScreenControls.SetActive(true);
                scr_Player.isMobile = true;
                break;
            case RuntimePlatform.WindowsEditor:
                onScreenControls.SetActive(false);
                break;
            default:
                onScreenControls.SetActive(false);
                break;
        }
    }

}

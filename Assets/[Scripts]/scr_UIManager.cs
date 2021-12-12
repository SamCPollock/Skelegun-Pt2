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


    private void CheckPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                onScreenControls.SetActive(true);
                scr_Player.isMobile = true;
                break;
            case RuntimePlatform.WindowsEditor:
                onScreenControls.SetActive(true);
                break;
            default:
                onScreenControls.SetActive(false);
                break;
        }
    }

}

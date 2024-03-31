using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800,600,true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("WorksResolution");
    }
}

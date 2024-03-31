using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800,600,true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("WorksResolution");
    }
}

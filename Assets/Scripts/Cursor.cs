using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUi : MonoBehaviour
{
    public void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

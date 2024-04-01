using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject Walls;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Walls.SetActive(true);
    }
}

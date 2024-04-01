using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject Walls;
    public GameObject Boss;
    public GameObject Roomtrigger;

    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Walls.SetActive(true);
        aud.Play();
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(3);
        Boss.SetActive(true);
        Roomtrigger.SetActive(false);
    }
}

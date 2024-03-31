using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    AudioSource changedSound;
    [SerializeField] private AudioClip interactSound;
    private RectTransform rect;
    private int currentPosition;

    void Start() 
    {
    changedSound = GetComponent<AudioSource>();
    }

    private void Awake() 
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);
    }

    private void ChangePosition(int _change) 
    {
        currentPosition += _change;

        if (_change !=0)
            changedSound.Play();

        if(currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

        //Move arrow up/down
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }
}

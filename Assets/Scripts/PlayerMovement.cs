using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _movement;

    private Rigidbody2D _rb;
    private Animator _animator;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";


    private void OnEnable ()
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovement;
    }


    private void OnDisable ()
    {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
    }

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        EnablePlayerMovement();
    }

    private void Update() 
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        _rb.velocity = _movement * _moveSpeed;

        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        if(_movement != Vector2.zero) 
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
        }
    }

    private void DisablePlayerMovement() 
    {
        _rb.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement() 
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }
}

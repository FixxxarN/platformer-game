using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementSpeed = 1f;
    private float _jumpHeight = 4.5f;
    private Rigidbody2D _rigidBody;

    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private float _groundCheckRadius;
    [SerializeField]
    private LayerMask _whatIsGround;
    private bool _isGrounded;
    private bool _isSneaking;
    private bool _isRunning;
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);
    }


    void Update()
    {
        Movement();
        Jump();
        Run();
        Sneak();
        ResetMovement();
    }

    private void ResetMovement()
    {
        if(!Input.GetKey(KeyCode.LeftControl)) {
            _isSneaking = false;
        }
        if(!Input.GetKey(KeyCode.LeftShift))
        {
            _isRunning = false;
        }
        if (!_isSneaking && !_isRunning)
            _movementSpeed = 1;
    }

    private void Sneak()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !_isRunning)
        {
            _isSneaking = true;
            _movementSpeed = 0.5f;
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !_isSneaking)
        {
            _isRunning = true;
            _movementSpeed = 2f;
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpHeight);
        }
    }

    private void Movement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _rigidBody.velocity = new Vector2(-_movementSpeed, _rigidBody.velocity.y);
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            _rigidBody.velocity = new Vector2(_movementSpeed, _rigidBody.velocity.y);
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
        }
    }
}

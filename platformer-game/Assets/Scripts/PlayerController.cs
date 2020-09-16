using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    private Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = new Vector2(-movementSpeed, rigidBody.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = new Vector2(movementSpeed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }
}

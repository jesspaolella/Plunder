using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // move speed of player
    public Rigidbody2D rb; // reference to rb
    private Vector2 moveDirection; // 2D vector representing sprite

    private float dashTime; // current time remaining on dash
    public float dashLength; // how long are dashes?
    private bool dashing; // is player dashing atm

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = dashLength;
    }

    // Update is called once per frame (depends on FPS, use for inputs)
    void Update()
    {
        if(!dashing)
        {
            ProcessInputs();
        }
    }

    void FixedUpdate() // gets called no matter FPS; use for physics
    {
        if(dashing)
        {
            Dash();
        }
        else
        {
            Move();
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // [-1, 0, or 1]
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; 
        if(!dashing && Input.GetKeyDown("left shift"))
        {
            dashing = true;
        }
        // create a Vector2, using inputs as x and y
        // normalize -> makes sure vector is length 1, so diagonal is same speed
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); // new vector2, mult by movespeed, then set rigidbody2D
    }

    void Dash()
    {
        if(dashTime <= 0)
        {
            dashing = false;
            dashTime = dashLength;
            rb.velocity = Vector2.zero;
        } else {
            dashTime -= Time.deltaTime;
            rb.velocity = new Vector2(moveDirection.x * moveSpeed * 3, moveDirection.y * moveSpeed * 3); // new vector2, mult by movespeed, then set rigidbody2D
        }
    }
}

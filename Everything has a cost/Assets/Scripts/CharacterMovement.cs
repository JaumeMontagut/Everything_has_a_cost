﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed = 200;
    public float jumpVelocity = 10;
    private float axisValue;
    private Rigidbody2D rb;
    private Vector2 movementVec;
    private Vector2 transformVec;
    public LayerMask Jumpable;
    //Animation & feathers
    private bool movingLeft = false;
    private bool movingRight = false;
    private bool jumping = false;
    private float groundedDist = 1;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
    {
        Move();
        Jump();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity +=  new Vector2 (0, jumpVelocity);
        }
    }

    bool IsGrounded()
    {
        Vector2 transform2D = Transform2D();

        Debug.DrawLine(
            transform.position,
            new Vector3(transform.position.x, transform.position.y - groundedDist, transform.position.z),
            Color.red,
            0.5f);

        return Physics2D.Linecast(
            transform2D,
            transform2D + new Vector2 (0, -groundedDist),
            Jumpable);
    }

    Vector2 Transform2D()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

}

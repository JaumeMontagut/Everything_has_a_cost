using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed = 200;
    public float jumpVelocity = 10;
    private Rigidbody2D rb;
    public LayerMask Jumpable;
    private float groundedDist = 1;
    private Animator anim;
    bool grounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();

        CheckGrounded();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        
        //Flip sprite and control animations
        if (rb.velocity.x != 0)
        {
            anim.SetBool("IsMoving", true);

            if (rb.velocity.x > 0)
            {
                if (transform.localScale.x != 1) { transform.localScale = new Vector3(1, 1, 1); }
            }
            else if (rb.velocity.x < 0)
            {
                if (transform.localScale.x != -1) { transform.localScale = new Vector3(-1, 1, 1); }
            }
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector2(0, jumpVelocity);
            anim.SetTrigger("Wingbeat");
        }
    }

    void CheckGrounded()
    {
        Vector2 transform2D = Transform2D();
        anim.SetBool("IsGrounded", Physics2D.Linecast(transform2D, transform2D + new Vector2(0, -groundedDist), Jumpable));

        //Debug.DrawLine(transform.position, transform.position + new Vector3(0, -groundedDist, 0), Color.red, 0.5f);
    }

    Vector2 Transform2D()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}

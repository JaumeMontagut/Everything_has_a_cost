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
    private FeatherController featherCtr;
    bool wingbeatRequest = false;

    private float lowGrav = 0.25f;
    private float normalGrav = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        featherCtr = GetComponent<FeatherController>();
    }

    void Update()
    {
        JumpInput();
    }

    void FixedUpdate()
    {
        Wingbeat();
        SetAnimations();
    }

    void JumpInput()
    {
        if (Input.GetButtonDown("Jump") && featherCtr.activeFeathers > 0)
        {
            wingbeatRequest = true;
        }
    }

    void Wingbeat()
    {
        if (wingbeatRequest)
        {
            //Reset velocity
            //rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * jumpVelocity, Input.GetAxisRaw("Vertical") * jumpVelocity) , ForceMode2D.Impulse);
            anim.SetTrigger("Wingbeat");
            featherCtr.activeFeathers--;
            featherCtr.ChangeFeatherText();
            wingbeatRequest = false;
        }

        if (rb.velocity.y < 0 && Input.GetButton("Jump"))
        {
            //If the player is still holding the button fall down slowly
            rb.gravityScale = lowGrav;
        }
        else
        {
            rb.gravityScale = normalGrav;
        }
    }

    void SetAnimations()
    {
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

        Vector2 transform2D = Transform2D();
        anim.SetBool("IsGrounded", Physics2D.Linecast(transform2D, transform2D + new Vector2(0, -groundedDist), Jumpable));

        //Debug.DrawLine(transform.position, transform.position + new Vector3(0, -groundedDist, 0), Color.red, 0.5f);
    }

    Vector2 Transform2D()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}

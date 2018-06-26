using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed = 200;
    public float jumpVelocity = 10;
    public LayerMask Jumpable;
    public GameObject attackFeather;
    public UIManager uiManager;

    private bool alive = true;
    private Rigidbody2D rb;
    private float groundedDist = 1;
    private Animator anim;
    private bool grounded = true;
    private FeatherController featherCtr;
    private bool wingbeatRequest = false;

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
        if (Input.GetButtonDown("Jump") && alive)
        {
            wingbeatRequest = true;
        }
    }

    void Wingbeat()
    {
        if (wingbeatRequest)
        {
            Vector2 wingbeatDir;
            wingbeatDir.x = Input.GetAxisRaw("Horizontal");
            wingbeatDir.y = Input.GetAxisRaw("Vertical");

            //Move character
            rb.AddForce(wingbeatDir * jumpVelocity, ForceMode2D.Impulse);

            //Throw feather
            //- Get the rotation
            float wingbeatRot;
            wingbeatRot = Mathf.Atan2(wingbeatDir.x, wingbeatDir.y);
            if (wingbeatRot < 0) { wingbeatRot = 2 * Mathf.PI - wingbeatRot; }
            //- Instanciate
            GameObject throwFeather;
            throwFeather = Instantiate(attackFeather, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(new Vector3(0, 0, wingbeatRot * 180 / 2 * Mathf.PI)));//+ 1 = Right now it comes out of the center of the player
            throwFeather.GetComponent<AttackFeatherMov>().translationVec = new Vector3(-wingbeatDir.x, -wingbeatDir.y, 0);
            //- Deactivate one feather on the wing
            featherCtr.activeFeathers--;
            featherCtr.ChangeFeatherText();
            if (featherCtr.activeFeathers < 1) { Die(); }

            //Animation
            anim.SetTrigger("Wingbeat");
           
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

    void Die()
    {
        alive = false;
        uiManager.ActivateLostUI();
    }
}

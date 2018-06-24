using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed = 100000;
    public float jumpHeight = 10;
    private float axisValue;
    private Rigidbody2D rb;
    //Animation & feathers
    private bool movingLeft = false;
    private bool movingRight = false;
    private bool jumping = false;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
    {
        //IMPLEMENTATION 1
        //if (Input.GetAxisRaw("Horizontal") != 0)
        //{
        //    transform.position.x += moveSpeed * Input.GetAxisRaw("Horizontal");
        //    if (Input.GetAxisRaw("Horizontal") > 0)
        //    {
        //        movingRight = true;//Millor fer un bool i fer que el anim canvii si esta a > o < que 0
        //    }
        //    else
        //    {
        //        movingLeft = true;
        //    }
        //}

        //IMPLEMENTATION 2
        //rb.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0));
    }
}

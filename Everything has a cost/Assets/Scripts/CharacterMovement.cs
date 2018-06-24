using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed = 200;
    public float jumpHeight = 10;
    private float axisValue;
    private Rigidbody2D rb;
    private Vector2 movementVec;
    private Vector2 transformVec;
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
        rb.velocity = new Vector2 (moveSpeed * Input.GetAxisRaw("Horizontal"), 0);
    }
}

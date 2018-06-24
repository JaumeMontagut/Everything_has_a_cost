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
        movementVec = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);//Add jump in here or not?
        transformVec = new Vector2(transform.position.x, transform.position.y);
        rb.MovePosition(transformVec + movementVec);
    }
}

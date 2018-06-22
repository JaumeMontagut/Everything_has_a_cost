using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherRotation : MonoBehaviour
{

    private float rotateSpeed = 400;

	void Start ()
    {
        //TO DO: Get the character (so that we can determine if it is changing its position or not)
	}

	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Hello");
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.Self);
            //TO DO: Not surpass maximum rotation
            //TO DO: Change for when the character is moving one way or the other
        }
        else if (Input.GetKey(KeyCode.D))
        {

        }
        else
        {
            //TO DO: Return to basic
        }
	}

    //void RotateFeather (float rotateSpeed, float rotateLimit)
    //{
    //    if ()//Current rotation != rotateLimit
    //    {
    //        if ()//CurrentRotation + roateSpeed < rotateLimit//think that this has to work with negative numbers too
    //        {
    //            //Rotate
    //        }
    //        else
    //        {
    //            //CurrentRotation = rotateLimit
    //        }
    //    }
    //}
}

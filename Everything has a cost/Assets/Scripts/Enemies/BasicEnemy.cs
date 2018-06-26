using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public GameObject pickUpFeather;

    public Vector3[] patrolPoints;//The different points the enemy will patrol to
    private int targetPoint;

    private float speed = 0.5f;

    private Vector3 difVec;//The vector that connects the current point with the target
    private Vector3 moveVec;//The vector we're going to move the enemy

    //Supports moving patrol points, as the direction is calculated every frame
	void Update ()
    {
        //Calculate the direction
        difVec = patrolPoints[targetPoint] - transform.position;
        moveVec = difVec.normalized * speed;
        //Move
        if (moveVec.magnitude < difVec.magnitude)
        {
            transform.Translate(moveVec);
        }
        else
        {
            //The distance is less than the one we're travelling, so go to the next point
            transform.position = patrolPoints[targetPoint];
            targetPoint++;
            if (targetPoint > patrolPoints.Length - 1)
            {
                targetPoint = 0;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(col.gameObject);
            Vector3 distanceBetweenFeathers = new Vector3 (0.2f, 0, 0);
            Vector3 initPos = transform.position - distanceBetweenFeathers * 5;
            for(int i = 0; i < 10; i++)
            {
                Instantiate(pickUpFeather, initPos + distanceBetweenFeathers * i, Quaternion.identity);
                //Get the sprite renderer and change the feather color
            }
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    bool movingTo1 = true;
    private Vector2 direction;
    private float directionX;
    private float directionY;
    private float speed = 1;
    private float turningDist = 1f;
    float module;

	void Start ()
    {
        CalculateDirection(new Vector2(point1.position.x, point1.position.y));
    }

	void Update ()
    {
        if (movingTo1)
        {
            Debug.Log(direction.x);
            transform.Translate(new Vector3 (direction.x * speed, direction.y * speed, 0) * Time.deltaTime);
            if(Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(point1.position.x, point1.position.y)) < module * speed)
            {
                CalculateDirection(new Vector2(point1.position.x, point1.position.y));
                movingTo1 = false;
            }
           
        }
        else
        {
            //transform.Translate(new Vector3(direction.x * speed, direction.y * speed, 0) * Time.deltaTime);
            if(Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(point2.position.x, point2.position.y)) < module * speed)
            {
                CalculateDirection(new Vector2(point2.position.x, point2.position.y));
                movingTo1 = true;
            }
            
        }
	}

    void CalculateDirection(Vector2 point)
    {
        if (transform.position.x > point.x)
        {
            directionX = transform.position.x - point.x;
        }
        else
        {
            directionX = point.x - transform.position.x;
        }

        if (transform.position.y > point.y)
        {
            directionY = transform.position.y - point.y;
        }
        else
        {
            directionY = point.y - transform.position.y;
        }

        direction = new Vector2(directionX, directionY);

        //Make the unit vector
        module = Mathf.Sqrt(Mathf.Pow(directionX, 2) * Mathf.Pow(directionY, 2));
        direction = new Vector2(directionX / module, directionY / module);
    }
}

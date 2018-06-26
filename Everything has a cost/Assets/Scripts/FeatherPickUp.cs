using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherPickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<FeatherController>().AddFeather();//Pass the color as a parameter
            Destroy(this.gameObject);
        }
    }
}

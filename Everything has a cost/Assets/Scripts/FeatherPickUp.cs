using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherPickUp : MonoBehaviour
{
    [HideInInspector] public Color featherColor;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<FeatherController>().AddFeather(featherColor);
            Destroy(this.gameObject);
        }
    }
}

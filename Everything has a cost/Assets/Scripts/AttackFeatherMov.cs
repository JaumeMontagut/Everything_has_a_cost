using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFeatherMov : MonoBehaviour {

    [HideInInspector] public Vector3 translationVec;

	void Update ()
    {
        transform.Translate(translationVec, Space.World);
	}

    //Delete when it touches the ground
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}

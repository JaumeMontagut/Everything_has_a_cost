using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFeatherMov : MonoBehaviour {

    [HideInInspector] public Vector3 translationVec;

	void Update ()
    {
        transform.Translate(translationVec, Space.World);
	}
}

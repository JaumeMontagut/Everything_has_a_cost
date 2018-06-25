using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherController : MonoBehaviour {

    enum FeatherState
    {
        empty,
        travelling,
        ocuppied
    };

    public Transform LWing;
    public GameObject[] feathers;

    private FeatherState[] feathersState;
    private int featherRows = 10;
    private int[] feathersInEachRow;
    private float radius = 10;//radius changes =/
    private float maxAngle;//A fixed angle value (where the body of the bird starts)

    //Control both wings on the same script



	void Start () {

	}

	void Update () {

        int featherNum = 0;
        float currentAngle = LWing.transform.rotation.z;

        for (int i = 0; i < featherRows; ++i)
        {
            float featherSeparation = (maxAngle - currentAngle) / feathersInEachRow[i];

            for (int j = 0; j < feathersInEachRow[i]; ++j)
            {
                feathers[featherNum].transform.position = new Vector3(
                        radius * Mathf.Cos(currentAngle + featherSeparation * j),
                        radius * Mathf.Sin(currentAngle + featherSeparation * j),
                        feathers[featherNum].transform.position.z);
                ++featherNum;
            }
        }

        //foreach (GameObject f in feathers)
        //{

        //}
	}
}

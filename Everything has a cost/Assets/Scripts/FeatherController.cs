using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeatherController : MonoBehaviour {

    enum FeatherState
    {
        empty,
        travelling,
        ocuppied
    };

    public Transform LWing;
    public Transform RWing;
    public GameObject[] feathers;
    public Text featherText;

    private FeatherState[] feathersState;
    private int featherRows = 6;
    private int[] feathersInEachRow = new int[6];//6 = featherRows
    private float radius;
    private float maxAngle = 150 * Mathf.PI / 180;//The angle at which the body of the bird starts
    private int maxFeathers = 70;

    //Control both wings on the same script
    private int featherNum;
    private float currentAngle;
    private float featherSeparation;
    private float endAngle;
    private float startAngle;
    [HideInInspector] public int activeFeathers = 70;

    void Start ()
    {
        feathersInEachRow[0] =  3;
        feathersInEachRow[1] =  5;
        feathersInEachRow[2] =  7;
        feathersInEachRow[3] =  9;
        feathersInEachRow[4] = 11;
        feathersInEachRow[5] = 13;//35 feathers on each wing, 70 total
    }

	void Update ()
    {
        LeftWing();
        RightWing();
    }

    private void LeftWing()
    {
        featherNum = 0;
        radius = 0.25f;
        currentAngle = LWing.transform.rotation.z * Mathf.PI / 180;

        //Set the start and end angle
        if (currentAngle < maxAngle)
        {
            startAngle = currentAngle;
            endAngle = maxAngle;
        }
        else
        {
            startAngle = maxAngle;
            endAngle = currentAngle;
        }

        //Position the feathers on the left wing
        for (int row = 0; row < featherRows; ++row)
        {
            featherSeparation = (endAngle - startAngle) / (feathersInEachRow[row] + 1);

            for (int rowFeather = 0; rowFeather < feathersInEachRow[row]; ++rowFeather)
            {
                if (feathers[featherNum].activeSelf == true)
                {

                    feathers[featherNum].transform.position = new Vector3(
                        radius * Mathf.Cos(Mathf.PI + featherSeparation * (rowFeather + 1)) + LWing.transform.position.x,//Mathf.PI = We need to invert the rotation (probably because Anima 2D is messing with the transforms)
                        radius * Mathf.Sin(Mathf.PI + featherSeparation * (rowFeather + 1)) + LWing.transform.position.y,
                        feathers[featherNum].transform.position.z);
                }
                ++featherNum;
            }
            radius += 0.25f;
        }
    }

    private void RightWing()
    {

    }

    public void ChangeFeatherText()//Called when we throw a feather
    {
        featherText.text = "Feathers: " + activeFeathers;
    }

    public void AddFeather()
    {
        if (activeFeathers < maxFeathers)
        {
            //activeFeathers++
        }
    }
}
//When picking up it checks rows from each wing first

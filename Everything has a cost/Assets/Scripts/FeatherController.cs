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
    private float startRadius = 0.25f;

    private float LcurrentAngle;
    private float LmaxAngle = 150 * Mathf.PI / 180;//The angle at which the body of the bird starts
    private float LstartAngle;
    private float LendAngle;
    private float LfeatherSeparation;

    private float RcurrentAngle;
    private float RmaxAngle = -160 * Mathf.PI / 180;//The angle at which the body of the bird starts
    private float RstartAngle;
    private float RendAngle;
    private float RfeatherSeparation;

    private int featherNum;
    private int maxFeathers = 70;    
    
    [HideInInspector] public int activeFeathers = 70;

    void Start ()
    {
        feathersInEachRow[0] =  3;
        feathersInEachRow[1] =  5;
        feathersInEachRow[2] =  7;
        feathersInEachRow[3] =  9;
        feathersInEachRow[4] = 11;
        feathersInEachRow[5] = 13;//35 feathers on each wing, 70 total

        //Set the sorting layer (behind the body or above it)
        for (int i = 0; i < 70; i +=2)//Even
        {
            feathers[i].GetComponent<SpriteRenderer>().sortingOrder = 18;
        }

        for (int i = 1; i < 70; i +=2)//Odd
        {
            feathers[i].GetComponent<SpriteRenderer>().sortingOrder =  2;
        }
    }

	void Update ()
    {
        PositionFeathers();
    }

    //IDEAL TO DO: Find a more controlled way to position the feathers (not have to check featherNum < maxFeathers every time)
    void PositionFeathers()
    {
        featherNum = 0;
        radius = startRadius;

        //Set the start and end angle for the left wing
        LcurrentAngle = LWing.transform.rotation.z * Mathf.PI / 180;
        if (LcurrentAngle < LmaxAngle)
        {
            LstartAngle = LcurrentAngle;
            LendAngle = LmaxAngle;
        }
        else
        {
            LstartAngle = LmaxAngle;
            LendAngle = LcurrentAngle;
        }

        //Set the start and end angle for the right wing
        RcurrentAngle = RWing.transform.rotation.z * Mathf.PI / 180;
        if (RcurrentAngle < LmaxAngle)
        {
            RstartAngle = RcurrentAngle;
            RendAngle = RmaxAngle;
        }
        else
        {
            RstartAngle = RmaxAngle;
            RendAngle = RcurrentAngle;
        }

        //Position the feathers on the left wing
        for (int row = 0; row < featherRows; ++row)
        {
            LfeatherSeparation = (LendAngle - LstartAngle) / (feathersInEachRow[row] + 1);
            RfeatherSeparation = (RendAngle - RstartAngle) / (feathersInEachRow[row] + 1);

            for (int rowFeather = 0; rowFeather < feathersInEachRow[row]; ++rowFeather)
            {
                //L wing feather
                if (featherNum < maxFeathers && feathers[featherNum].activeSelf)
                {
                    feathers[featherNum].transform.position = new Vector3(
                        radius * Mathf.Cos(Mathf.PI + LfeatherSeparation * (rowFeather + 1)) + LWing.transform.position.x,//Mathf.PI = We need to invert the rotation (probably because Anima 2D is messing with the transforms)
                        radius * Mathf.Sin(Mathf.PI + LfeatherSeparation * (rowFeather + 1)) + LWing.transform.position.y + 0.2f,
                        feathers[featherNum].transform.position.z);
                }
                ++featherNum;

                //R wing feather
                if (featherNum < maxFeathers && feathers[featherNum].activeSelf)
                {
                    feathers[featherNum].transform.position = new Vector3(
                        radius * Mathf.Cos(RfeatherSeparation * (rowFeather + 1)) + RWing.transform.position.x,
                        radius * Mathf.Sin(RfeatherSeparation * (rowFeather + 1)) + RWing.transform.position.y + 0.2f,
                        feathers[featherNum].transform.position.z);
                }
                ++featherNum;
            }
            radius += 0.25f;
        }
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

    public void HideFeather(int featherIndex)
    {
        feathers[featherIndex].SetActive(false);
    }
}
//When picking up it checks rows from each wing first

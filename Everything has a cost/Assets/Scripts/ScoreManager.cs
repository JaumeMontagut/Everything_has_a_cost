using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject player;
    private int maximumHeight;

	void Start ()
    {
		
	}

	void Update ()
    {
        if (player.transform.position.y > maximumHeight)
        {
            maximumHeight = (int)player.transform.position.y;
            scoreText.text = "Score:" + maximumHeight.ToString();
        }
	}
}

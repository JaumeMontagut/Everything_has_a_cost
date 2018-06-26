using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    private enum gameStage
    {
        start,
        playing,
        lost
    };

    // Start text
    public Text titleText;
    public Text instructions1Text;
    public Text instructions2Text;

    // Game text
    public Text scoreText;
    public Text feathersText;
    private int maximumHeight;

    // Game over text
    public Text gameOverText;
    public Text playAgainText;

    public GameObject player;
    private gameStage stage = gameStage.start;

    void Update()
    {
        switch (stage)
        {
            case gameStage.start:
                StartText();
                break;
            case gameStage.playing:
                GameText();
                break;
            case gameStage.lost:
                break;
        }
    }

    void StartText()
    {
        if (Input.GetButtonDown("Jump"))
        {
            titleText.gameObject.SetActive(false);
            instructions1Text.gameObject.SetActive(false);
            instructions2Text.gameObject.SetActive(false);

            scoreText.gameObject.SetActive(true);
            feathersText.gameObject.SetActive(true);

            stage = gameStage.playing;
        }
    }

    void GameText()
    {
        if (player.transform.position.y > maximumHeight)
        {
            maximumHeight = (int)player.transform.position.y;
            scoreText.text = "Score:" + maximumHeight.ToString();
        }
    }

    void LoseText()
    {
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene(0);//0 = current scene
        }
    }

    public void ActivateLostUI()
    {
        gameOverText.gameObject.SetActive(true);
        scoreText.rectTransform.position = new Vector3(300, -220, 0);//Set to the center of the screen
        stage = gameStage.lost;
    }

    public void ChangeFeatherText()//Called when we throw a feather
    {
        feathersText.text = "Feathers: " + player.GetComponent<FeatherController>().activeFeathers;
    }
}

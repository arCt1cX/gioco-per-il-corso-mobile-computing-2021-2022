using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public float scoreCounter;
    public float highscoreCounter;
    public float punti;
    public bool scoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highscoreCounter = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncrease)
        {
            scoreCounter += punti * Time.deltaTime;
        }

        if(scoreCounter > highscoreCounter)
        {
            highscoreCounter = scoreCounter;
            PlayerPrefs.SetFloat("HighScore", highscoreCounter);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCounter);
        highscoreText.text = "Highscore: " + Mathf.Round(highscoreCounter);
    }
}

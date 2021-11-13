using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;
    public string playGameLevel;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }

    public void Update()
    {
        highScore.text = "Highscore: " +Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
    }
}

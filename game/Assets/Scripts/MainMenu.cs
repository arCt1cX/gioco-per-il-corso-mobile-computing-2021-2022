using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;
    public string playGameLevel;
    public AudioClip audioGioco;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
        if (SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        if(BackgroundMusic.backgroundMusic.soundToggle == true)
        BackgroundMusic.backgroundMusic.ChangeBackgroundMusic(audioGioco);
    }

    public void Update()
    {
        highScore.text = "Highscore: " +Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string mainMenuLevel;
    public GameObject pauseMenu;
    public AudioClip audioMenu;
    private float currentTime;

    public void PauseGame()
    {
        currentTime = Time.timeScale;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        if (BackgroundMusic.backgroundMusic.soundToggle == true)
            BackgroundMusic.backgroundMusic.Audio.Pause();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        if (BackgroundMusic.backgroundMusic.soundToggle == true)
            BackgroundMusic.backgroundMusic.Audio.UnPause();
        Time.timeScale = currentTime;
        if (SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        if (SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(mainMenuLevel);
        if (BackgroundMusic.backgroundMusic.soundToggle == true)
            BackgroundMusic.backgroundMusic.ChangeBackgroundMusic(audioMenu);
        if (SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
}

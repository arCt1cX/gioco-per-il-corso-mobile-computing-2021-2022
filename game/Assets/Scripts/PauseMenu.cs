using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string mainMenuLevel;
    public GameObject pauseMenu;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(mainMenuLevel);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
}

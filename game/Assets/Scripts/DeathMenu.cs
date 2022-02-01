using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public AudioClip audioMenu;
    public string mainMenuLevel;
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
        if(SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
    public void QuitToMenu()
    {
        if (BackgroundMusic.backgroundMusic.soundToggle == true)
            BackgroundMusic.backgroundMusic.ChangeBackgroundMusic(audioMenu);
        if(SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        SceneManager.LoadScene(mainMenuLevel);

    }
}

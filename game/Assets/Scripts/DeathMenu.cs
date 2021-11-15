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
        SceneManager.LoadScene(mainMenuLevel);
        if (BackgroundMusic.backgroundMusic.soundToggle == true)
            BackgroundMusic.backgroundMusic.ChangeBackgroundMusic(audioMenu);
        if(SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
}

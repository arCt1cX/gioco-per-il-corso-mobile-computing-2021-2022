using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public string mainMenuLevel;
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(mainMenuLevel);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

    }
}

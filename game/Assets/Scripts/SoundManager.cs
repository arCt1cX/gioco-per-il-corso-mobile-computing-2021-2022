using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;
    [SerializeField] Image sfxOn;
    [SerializeField] Image sfxOff;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("soundtoggle"))
        {
            PlayerPrefs.SetInt("soundtoggle", 1);
            LoadBg();
        }
        else
        {
            LoadBg();
        }

        if(!PlayerPrefs.HasKey("musictoggle"))
        {
            PlayerPrefs.SetInt("musictoggle", 1);
            LoadSfx();
        }
        else
        {
            LoadSfx();
        }

        if (BackgroundMusic.backgroundMusic.Audio.isPlaying)
        {
            soundOn.gameObject.SetActive(true);
            soundOff.gameObject.SetActive(false);
        }
        else
        {
            soundOn.gameObject.SetActive(false);
            soundOff.gameObject.SetActive(true);
        }

        //sfx
        if (SfxManager.sfxInstance.musicToggle == true)
        {
            sfxOn.gameObject.SetActive(true);
            sfxOff.gameObject.SetActive(false);
        }
        else
        {
            sfxOn.gameObject.SetActive(false);
            sfxOff.gameObject.SetActive(true);
        }
    }

    public void SfxToggle()
    {

        if(SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

        if (SfxManager.sfxInstance.musicToggle == true)
        {
            SfxManager.sfxInstance.musicToggle = false;
            sfxOn.gameObject.SetActive(false);
            sfxOff.gameObject.SetActive(true);
        }
        else
        {
            SfxManager.sfxInstance.musicToggle = true;
            sfxOn.gameObject.SetActive(true);
            sfxOff.gameObject.SetActive(false);
        }
        SaveSfx();
    }

    public void MusicToggle()
    {
        if (SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);

        if (BackgroundMusic.backgroundMusic.Audio.isPlaying)
        {
            BackgroundMusic.backgroundMusic.soundToggle = false;
            BackgroundMusic.backgroundMusic.Audio.Pause();
            soundOn.gameObject.SetActive(false);
            soundOff.gameObject.SetActive(true);
        }
        else
        {
            BackgroundMusic.backgroundMusic.soundToggle = true;
            BackgroundMusic.backgroundMusic.Audio.Play();
            soundOn.gameObject.SetActive(true);
            soundOff.gameObject.SetActive(false);
        }
        SaveBg();
    }
    private void LoadBg()
    {
       BackgroundMusic.backgroundMusic.soundToggle = PlayerPrefs.GetInt("soundtoggle") == 1;
    }

    private void LoadSfx()
    {
        SfxManager.sfxInstance.musicToggle = PlayerPrefs.GetInt("musictoggle") == 1;
    }

    private void SaveBg()
    {
        PlayerPrefs.SetInt("soundtoggle", BackgroundMusic.backgroundMusic.soundToggle ? 1 : 0);
    }

    private void SaveSfx()
    {
        PlayerPrefs.SetInt("musictoggle", SfxManager.sfxInstance.musicToggle ? 1 : 0);
    }
}

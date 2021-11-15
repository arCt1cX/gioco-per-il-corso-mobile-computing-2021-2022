using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic backgroundMusic;
    public AudioSource Audio;
    public bool soundToggle = true;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeBackgroundMusic(AudioClip music)
    {
        Audio.Stop();
        Audio.clip = music;
        Audio.Play();
    }
}

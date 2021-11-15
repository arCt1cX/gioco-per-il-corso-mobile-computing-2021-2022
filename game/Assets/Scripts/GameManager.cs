using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Switch giocatore;
    public GameObject player;
    private Vector2 playerStartPoint;
    public LevelGenerator generatore;
    private Vector2 endPosition;
    public GameObject endposition;
    private ScoreManager scoreManager;
    public DeathMenu deathMenu;


    // Start is called before the first frame update
    void Start()
    {
        player.transform.Find("coso verde con sopracciglia").gameObject.SetActive(false);
        endPosition = endposition.transform.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        if(scoreManager.scoreIncrease == true)
        {
        scoreManager.scoreIncrease = false;
        }
        player.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);
        if (BackgroundMusic.backgroundMusic.soundToggle == true)
            BackgroundMusic.backgroundMusic.Audio.Stop();
    }

    public void Reset()
    {
        if (!player.transform.Find("coso rosso con sopracciglia").gameObject.activeInHierarchy)
        {
            player.transform.Find("coso rosso con sopracciglia").gameObject.SetActive(true);
            player.transform.Find("coso verde con sopracciglia").gameObject.SetActive(false);
            if (giocatore.getAttivo() == 2)
            {
                giocatore.setAttivo(1);
            }
        }
        Vector3 eulerRotation = player.transform.eulerAngles;
        eulerRotation.Set(0, 0, 0);
        deathMenu.gameObject.SetActive(false);
        foreach (var pooled in generatore.getPooled())
        {
            if (!pooled) continue;

            Destroy(pooled.gameObject);
        }
        this.generatore.getPooled().Clear();
        player.transform.position = playerStartPoint;
        generatore.SetEndPosition(endPosition);
        if (BackgroundMusic.backgroundMusic.soundToggle == true)
            BackgroundMusic.backgroundMusic.Audio.Play();
        player.gameObject.SetActive(true);
        scoreManager.scoreCounter = 0;
        scoreManager.scoreIncrease = true;
    }

}

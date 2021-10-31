using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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
        endPosition = endposition.transform.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        scoreManager.scoreIncrease = false;
        player.gameObject.SetActive(false);
       // System.Threading.Thread.Sleep(1000);
        deathMenu.gameObject.SetActive(true);
    }

    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);
        for (int i = 0; i < generatore.getPooled().Count; i++)
        {
            if (generatore.getPooled()[i] == null)
            {
                i++;
            }

            else
            {
                generatore.getPooled()[i].gameObject.SetActive(false);
                if (!generatore.getPooled()[i].gameObject.activeInHierarchy)
                {
                    Destroy(generatore.getPooled()[i].gameObject);
                }
                if (i > 0)
                {
                    if (generatore.getPooled()[i - 1] == null && generatore.getPooled()[i + 1] == null)
                    {
                        Destroy(generatore.getPooled()[i].gameObject);
                    }
                }

            }
        }
        player.transform.position = playerStartPoint;
        generatore.SetEndPosition(endPosition);
        player.gameObject.SetActive(true);
        scoreManager.scoreCounter = 0;
        scoreManager.scoreIncrease = true;
    }
}

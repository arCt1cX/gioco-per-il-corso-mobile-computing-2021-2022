using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 150f;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;
    public List<Transform> pooled;
    public GameManager gameManager;
    private Vector2 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("pavimento normale").Find("endposition").position;
        int startingSpawnLevelParts = 5;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if(Vector2.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];       
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("endposition").position;
    } 

    private Transform SpawnLevelPart(Transform levelPart, Vector2 spawnPosition) 
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        pooled.Add(levelPartTransform);
        return levelPartTransform;
    }

    public List<Transform> getPooled()
    {
        return pooled;
    }

    public void SetEndPosition(Vector2 newEndPosition)
    {
        lastEndPosition = newEndPosition;
    }
}

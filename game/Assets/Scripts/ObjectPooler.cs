using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [SerializeField] List<GameObject> pooledObjectList;
    public int quantita;
    List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i <= quantita; i++)
        {
            GameObject chosenPart = pooledObjectList[Random.Range(0, pooledObjectList.Count)];
            GameObject obj = (GameObject)Instantiate(chosenPart);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooled()
    {
        for(int i = 0; i<pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject chosenPart = pooledObjectList[Random.Range(0, pooledObjectList.Count)];
        GameObject obj = (GameObject)Instantiate(chosenPart);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
    
}

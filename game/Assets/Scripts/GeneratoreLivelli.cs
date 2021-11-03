using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratoreLivelli : MonoBehaviour
{

    private GameObject platform;
    public Transform puntoGenerazione;
    public float distanza;

    private float platformWidth;
    public float distanzaMin;
    public float distanzaMax;
    public ObjectPooler objectPool;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = objectPool.GetPooled().GetComponent<PolygonCollider2D>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < puntoGenerazione.position.x)
        {
            distanza = Random.Range(distanzaMin, distanzaMax);
            transform.position = new Vector2(transform.position.x + platformWidth + distanza, transform.position.y);
            // Instantiate(platform, transform.position, transform.rotation);
            GameObject platform = objectPool.GetPooled();
            platform.transform.position = transform.position;
            platform.transform.rotation = transform.rotation;
            platform.SetActive(true);
        }
    }
}

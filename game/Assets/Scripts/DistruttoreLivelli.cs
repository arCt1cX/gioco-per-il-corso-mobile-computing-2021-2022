using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistruttoreLivelli : MonoBehaviour
{

    public GameObject puntoDistruzione;
    // Start is called before the first frame update
    void Start()
    {
        puntoDistruzione = GameObject.Find("punto_distruzione");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < puntoDistruzione.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}

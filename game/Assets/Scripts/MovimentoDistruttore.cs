using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDistruttore : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimento();
    }

    private void movimento()
    {
        rb.velocity = new Vector2(2.3f, rb.velocity.y);
    }
}

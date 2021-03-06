using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Betterjump : MonoBehaviour
{

    public float caduta = 2.5f;
    public float lowJumpMult = 2f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (caduta - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !(Input.touchCount > 0)) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;
        }
    }
}




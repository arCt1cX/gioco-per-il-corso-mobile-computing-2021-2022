using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem parryEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "parry")
        {
            ParticleSystem effect = Instantiate(parryEffect, new Vector3(collision.transform.position.x, collision.transform.position.y, -1), Quaternion.identity);
            effect.Play();
                float velocitaSalto = 10f;
                rb.velocity = Vector2.up * velocitaSalto;
        }
    }
}

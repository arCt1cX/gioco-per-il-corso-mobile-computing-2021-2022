using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private LayerMask layerMask;    
    private BoxCollider2D bc;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTerreno()) {
            float velocitaSalto = 7f;
            rb.velocity = Vector2.up * velocitaSalto;
        }

        movimento();
    }

    private bool isTerreno()
        {
            RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, layerMask);
            Debug.Log(raycastHit2d.collider);
            return (raycastHit2d.collider != null);
        }

    private  void movimento()
    {
        rb.velocity = new Vector2(4f, rb.velocity.y);
    }
    }

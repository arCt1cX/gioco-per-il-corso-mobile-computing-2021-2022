using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private LayerMask layerMask;    
    private BoxCollider2D bc;
    private Animator myAnimator;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        player = GameObject.Find("coso rosso con sopracciglia");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTerreno())
        {
            float velocitaSalto = 7f;
            rb.velocity = Vector2.up * velocitaSalto;
        }
        movimento();
        myAnimator.SetBool("terreno", isTerreno());
        myAnimator.SetBool("rotola", isRotolando());
    }


    private bool isRotolando()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if ((eulerRotation.z <= 150 && eulerRotation.z >= -150) || !isTerreno())
            return false;
        return true;
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

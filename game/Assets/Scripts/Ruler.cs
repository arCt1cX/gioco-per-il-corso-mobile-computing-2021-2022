using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : MonoBehaviour
{ 
    [SerializeField] private LayerMask layerMask;
    private BoxCollider2D bc;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool isRulteter()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.up, .1f, layerMask);
        Debug.Log(raycastHit2d.collider);
        return (raycastHit2d.collider != null);
    }
}

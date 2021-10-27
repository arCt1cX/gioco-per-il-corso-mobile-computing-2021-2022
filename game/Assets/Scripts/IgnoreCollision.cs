using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    public PolygonCollider2D parry;
    public BoxCollider2D player;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(parry, player, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animazioni : MonoBehaviour
{
    private BoxCollider2D bc;
    public GameObject rosso;
    public GameObject verde;
    public Sprite rossoSalto;
    public Sprite verdeSalto;
    public Sprite rossoRotola;
    private SpriteRenderer srNewRosso;
    private SpriteRenderer srNewVerde;
    public Sprite rossoCammina;
    public Sprite verdeCammina;
    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        srNewRosso = rosso.GetComponent<SpriteRenderer>();
        srNewVerde = verde.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rosso.activeInHierarchy)
        {
            if(isRotolando())
            {
                if(!isTerreno())
                {
                    srNewRosso.sprite = rossoSalto;
                }
                else
                {
                    srNewRosso.sprite = rossoRotola;
                }
            }
            else if(!isTerreno())
            {
                srNewRosso.sprite = rossoSalto;
            }
            else
            {
                srNewRosso.sprite = rossoCammina;
            }
        }
        else if(verde.activeInHierarchy)
        {
            if(!isTerreno())
            {
                srNewVerde.sprite = verdeSalto;
            }
            else
            {
                srNewVerde.sprite = verdeCammina;
            }
        }

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
}

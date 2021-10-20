using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimazioniRosso : MonoBehaviour
{
    private Animator myAnimator;
    [SerializeField] private LayerMask layerMask;
    private BoxCollider2D bc;
    public Switch obj;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetBool("terreno", isTerreno());
        myAnimator.SetBool("rotola", isRotolando());
        myAnimator.SetBool("isRossoActive", obj.isRossoActive());
        myAnimator.SetBool("isVerdeActive", obj.isVerdeActive());
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

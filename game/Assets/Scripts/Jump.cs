using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask layerMask;    
    private BoxCollider2D bc;
    public GameManager theGameManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject() && isTerreno() && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.GetTouch(0).position.x < Screen.width/2)
            {
                float velocitaSalto = 7f;
                rb.velocity = Vector2.up * velocitaSalto;
            }
        }
        movimento();
        if (transform.position.x > speedMilestoneCount)
        {
            if (moveSpeed < 12)
            {
                speedMilestoneCount += speedIncreaseMilestone;
                speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
                moveSpeed = moveSpeed * speedMultiplier;
            }
        }
        
    }


    private bool isTerreno()
        {
            RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, layerMask);
            Debug.Log(raycastHit2d.collider);
            return (raycastHit2d.collider != null);
        }

    private  void movimento()
        {
        
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "distruttore")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }
}

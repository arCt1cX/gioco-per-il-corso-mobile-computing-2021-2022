using System;
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
    [SerializeField] private LayerMask layerMaskRuler;
    private BoxCollider2D bc;
    public GameManager theGameManager;
    public GameObject rosso;
    public GameObject verde;
    public ParticleSystem esplosioneRosso;
    public ParticleSystem esplosioneVerde;
    public ParticleSystem scoppioRosso;
    public ParticleSystem scoppioVerde;
    private float timeStore;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        speedMilestoneCount = speedIncreaseMilestone;
        timeStore = Time.timeScale;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f) {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 2 && !EventSystem.current.IsPointerOverGameObject(touch.fingerId) && isTerreno() && touch.phase == TouchPhase.Began)
                {
                    float velocitaSalto = 7f;
                    rb.velocity = Vector2.up * velocitaSalto;   
                }

                if(touch.position.x < Screen.width / 2 && isRuler() && !isTerreno())
                {
                    rb.velocity = Vector2.up * 3;
                    transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x + 5f, transform.localPosition.y), Time.deltaTime * 10f);
                }
            }
        }

        movimento();
        if (transform.position.x > speedMilestoneCount)
        {
            if (Time.timeScale <= 2)
            {
                speedMilestoneCount += speedIncreaseMilestone;
                speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
                Time.timeScale = Time.timeScale + 0.1f;
            }
        }
    }


    private bool isTerreno()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .3f, layerMask);
        Debug.Log(raycastHit2d.collider);
        return (raycastHit2d.collider != null);
    }

    private bool isRuler()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.up, .2f, layerMaskRuler);
        Debug.Log(raycastHit2d.collider);
        return (raycastHit2d.collider != null);
    }

    private void movimento()
    {
        rb.velocity = new Vector2(4f, rb.velocity.y);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "distruttore")
        {
            theGameManager.RestartGame();
            Time.timeScale = timeStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }

    private void BreakForSpikes()
    {
        if (rosso.gameObject.activeInHierarchy)
        {
            rb.gameObject.SetActive(false);
            ParticleSystem exRossa = Instantiate(esplosioneRosso, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            exRossa.Play();
            if (SfxManager.sfxInstance.musicToggle == true)
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.splat);
        }

        if (verde.gameObject.activeInHierarchy)
        {
            rb.gameObject.SetActive(false);
            ParticleSystem exVerde = Instantiate(esplosioneVerde, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            exVerde.Play();
            if (SfxManager.sfxInstance.musicToggle == true)
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.splat);
        }
    }
    
    private void BreakForRosso()
    {
            rb.gameObject.SetActive(false);
            ParticleSystem scoppio = Instantiate(scoppioRosso, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            scoppio.Play();
        if (SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.boomSplat);
    }

    private void BreakForVerde()
    {
            rb.gameObject.SetActive(false);
            ParticleSystem scoppio = Instantiate(scoppioVerde, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            scoppio.Play();
        if (SfxManager.sfxInstance.musicToggle == true)
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.boomSplat);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "spikes")
        {
            BreakForSpikes();
            FindObjectOfType<ScoreManager>().scoreIncrease = false;
            theGameManager.Invoke("RestartGame", 1.5f);
            Time.timeScale = timeStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }

        if (collision.gameObject.tag == "rosso")
        {
            if (verde.gameObject.activeInHierarchy)
            {
                BreakForVerde();
                FindObjectOfType<ScoreManager>().scoreIncrease = false;
                theGameManager.Invoke("RestartGame", 1.5f);
                Time.timeScale = timeStore;
                speedMilestoneCount = speedMilestoneCountStore;
                speedIncreaseMilestone = speedIncreaseMilestoneStore;
            }
        }

        if (collision.gameObject.tag == "verde")
        {
            if (rosso.gameObject.activeInHierarchy)
            {
                BreakForRosso();
                FindObjectOfType<ScoreManager>().scoreIncrease = false;
                theGameManager.Invoke("RestartGame", 1.5f);
                Time.timeScale = timeStore;
                speedMilestoneCount = speedMilestoneCountStore;
                speedIncreaseMilestone = speedIncreaseMilestoneStore;
            }
        }
    }
}


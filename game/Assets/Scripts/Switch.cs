using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Switch : MonoBehaviour
{
    public GameObject rosso;
    public GameObject verde;
    int attivo = 1;
    public ParticleSystem colorChange;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {
        SwitchAvatar();
    }

    public void SwitchAvatar()
    {
        if(Time.timeScale > 0f)
        { 
            foreach(Touch touch in Input.touches)
            {
                if(touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began && !IsPointerOverUIObject())
                {
                    switch (attivo)
                    {
                        case 1:
                            attivo = 2;
                            ParticleSystem change = Instantiate(colorChange, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                            change.Play();
                            rosso.gameObject.SetActive(false);
                            verde.gameObject.SetActive(true);
                            break;

                        case 2:
                            attivo = 1;
                            ParticleSystem change2 = Instantiate(colorChange, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
                            change2.Play();
                            verde.gameObject.SetActive(false);
                            rosso.gameObject.SetActive(true);
                            break;
                    }
                }
            }
        }
    }

    public bool isRossoActive()
    {
        if (attivo == 1)
            return true;
        return false;
    }

    public bool isVerdeActive()
    {
        if(attivo == 2)
            return true;
        return false;
    }

    public void setAttivo(int valore)
    {
        attivo = valore;
    }

    public int getAttivo()
    {
        return attivo;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

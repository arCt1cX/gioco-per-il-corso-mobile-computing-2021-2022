using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Switch : MonoBehaviour
{
    public GameObject rosso;
    public GameObject verde;
    int attivo = 1;

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
        { /*
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject() && Input.GetTouch(0).position.x > Screen.width / 2)
            {
                if (Input.GetTouch(0).position.x > Screen.width / 2)
                {
                    switch (attivo)
                    {
                        case 1:
                            attivo = 2;
                            rosso.gameObject.SetActive(false);
                            verde.gameObject.SetActive(true);
                            break;

                        case 2:
                            attivo = 1;
                            verde.gameObject.SetActive(false);
                            rosso.gameObject.SetActive(true);
                            break;
                    }
                }
            }*/
            foreach(Touch touch in Input.touches)
            {
                if(touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began && !IsPointerOverUIObject())
                {
                    switch (attivo)
                    {
                        case 1:
                            attivo = 2;
                            rosso.gameObject.SetActive(false);
                            verde.gameObject.SetActive(true);
                            break;

                        case 2:
                            attivo = 1;
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

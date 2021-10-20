using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject rosso;
    public GameObject verde;
    int attivo = 1;

    // Start is called before the first frame update
    void Start()
    {
        rosso.gameObject.SetActive(true);
        verde.gameObject.SetActive(false);
    }

    public void Update()
    {
        SwitchAvatar();
    }

    public void SwitchAvatar()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width/2)
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
                        rosso.gameObject.SetActive(true);
                        verde.gameObject.SetActive(false);
                        break;
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
}

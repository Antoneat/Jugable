using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TiendaController : MonoBehaviour
{

    public GameObject tiendaFirstBUtton;

    public TriggerSuccubo triggerSuccubo;

    void Update()
    {
            FirsButtonTienda();
    }

    public void FirsButtonTienda()
    {
        if (triggerSuccubo.Sucubo == false)
        {
            Time.timeScale = 0f;

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(tiendaFirstBUtton);

        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}

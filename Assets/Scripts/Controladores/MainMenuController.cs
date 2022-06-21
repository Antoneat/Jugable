using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{

    public GameObject optionsMainMenu, salaTrofeosInterfaz;

    public GameObject menuFirstButton, optionsFirstButtonMainMenu, optionsCloseButton, salaTrofeosFirstButton;

    public CamMovimientoMenu movimientoMenu;

    void Start()
    {
        //AudioManager.instance.Play("MenuSong");
        //clear selected object
        //EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
        }
    }


    public void OpenOptions()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[2];

        //optionsMainMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        //optionsMainMenu.SetActive(false);
        movimientoMenu.currentView = movimientoMenu.viewsMp[1];
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }
    public void OpenSalaTrofeos()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[3]; //sale de trofeos 1.1
    }

    public void CloseSalaTrofeos()
    {
        //optionsMainMenu.SetActive(false);
        movimientoMenu.currentView = movimientoMenu.viewsMp[6];
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

}

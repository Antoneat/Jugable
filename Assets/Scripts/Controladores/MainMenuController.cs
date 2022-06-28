using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{

    public GameObject optionsMainMenu, salaTrofeosInterfaz;

    public GameObject menuFirstButton, optionsFirstButtonMainMenu, optionsCloseButton, salaTrofeosFirstButton, closeButtonInfo;

    public CamMovimientoMenu movimientoMenu;

    public GameObject[] trofeosInfo;

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

    //ver a los trofeos views 8 - 12

    public void OpenCuchillo()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[8];
    }

    public void OpenCarta()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[9];
    }
    public void OpenBolsaColmillos()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[10];
    }
    public void OpenArmadura()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[11];
    }
    public void OpenTumba()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[12];
    }
    public void CloseInfo()
    {
        movimientoMenu.currentView = movimientoMenu.viewsMp[5];
    }

}

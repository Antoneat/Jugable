using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CamMovimientoMenu : MonoBehaviour
{
    public GameObject TextEnter;
    public GameObject HiMTitle;
    public GameObject MenuPrincipal;

    public Transform[] viewsMp;
    //public GameObject[] luces;

    public float transitionSpeedMp;

    public Transform currentView;

    public MainMenuController mainMenuController;


    void Start()
    {
        currentView = viewsMp[0];
    }


    void Update()
    {
        if (currentView == viewsMp[0]) //lugar inicial
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                currentView = viewsMp[1];
                TextEnter.SetActive(false);
                HiMTitle.SetActive(false);
            }
        }

        else if (currentView == viewsMp[3]) //sala de trofeos1.2
        {
                currentView = viewsMp[4];
        }
        else if (currentView == viewsMp[4]) //sala de trofeos 1.3
        {
                currentView = viewsMp[5];
        }
        else if (currentView == viewsMp[6]) //cerrar sala de trofeos 
        {
            currentView = viewsMp[7];
        }
        else if (currentView == viewsMp[7]) //cerrar sala de trofeos 1.3
        {
            currentView = viewsMp[1];
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeedMp);

        Vector3 currentAngle = new Vector3(
            Mathf.Lerp(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x,
            Time.deltaTime * transitionSpeedMp),

            Mathf.Lerp(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y,
            Time.deltaTime * transitionSpeedMp),

            Mathf.Lerp(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z,
            Time.deltaTime * transitionSpeedMp)

            );

        transform.eulerAngles = currentAngle;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag ==  "View1")
        {
            MenuPrincipal.SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.menuFirstButton);
        }
        else if (other.gameObject.tag == "View2")
        {
            mainMenuController.optionsMainMenu.SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.optionsFirstButtonMainMenu);
        }

        //SALA DE TROFEOS INTERFAZ
        else if (other.gameObject.tag == "View5")
        {
            mainMenuController.salaTrofeosInterfaz.SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.salaTrofeosFirstButton);
        }

        //Trofeos 8 - 12
        else if (other.gameObject.tag == "View8") //cuchillo
        {
            mainMenuController.trofeosInfo[0].SetActive(true);
            mainMenuController.closeButtonInfo.SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.closeButtonInfo);
        }
        else if (other.gameObject.tag == "View9") //carta
        {
            mainMenuController.trofeosInfo[1].SetActive(true);
            mainMenuController.closeButtonInfo.SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.closeButtonInfo);
        }
        else if (other.gameObject.tag == "View10") //bolsaColmillos
        {
            mainMenuController.closeButtonInfo.SetActive(true);
            mainMenuController.trofeosInfo[2].SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.closeButtonInfo);
        }
        else if (other.gameObject.tag == "View11") //armadura
        {
            mainMenuController.closeButtonInfo.SetActive(true);
            mainMenuController.trofeosInfo[3].SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.closeButtonInfo);
        }
        else if (other.gameObject.tag == "View12") //Tumba
        {
            mainMenuController.closeButtonInfo.SetActive(true);
            mainMenuController.trofeosInfo[4].SetActive(true);
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(mainMenuController.closeButtonInfo);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag ==  "View1")
        {
            MenuPrincipal.SetActive(false);
        }
        else if (other.gameObject.tag == "View2")
        {
            mainMenuController.optionsMainMenu.SetActive(false);
        }

        //SALA DE TROFEOS
        else if (other.gameObject.tag == "View5")
        {
            mainMenuController.salaTrofeosInterfaz.SetActive(false);
        }

        //Trofeos 8 - 12

        else if (other.gameObject.tag == "View8") //cuchillo
        {
            mainMenuController.closeButtonInfo.SetActive(false);
            mainMenuController.trofeosInfo[0].SetActive(false);
        }
        else if (other.gameObject.tag == "View9") //carta
        {
            mainMenuController.closeButtonInfo.SetActive(false);
            mainMenuController.trofeosInfo[1].SetActive(false);
        }
        else if (other.gameObject.tag == "View10") //bolsaColmillos
        {
            mainMenuController.closeButtonInfo.SetActive(false);
            mainMenuController.trofeosInfo[2].SetActive(false);
        }
        else if (other.gameObject.tag == "View11") //Armadura
        {
            mainMenuController.closeButtonInfo.SetActive(false);
            mainMenuController.trofeosInfo[3].SetActive(false);
        }
        else if (other.gameObject.tag == "View12") //Tumba
        {
            mainMenuController.closeButtonInfo.SetActive(false);
            mainMenuController.trofeosInfo[4].SetActive(false);
        }
    }
}

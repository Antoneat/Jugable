using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamMovimiento : MonoBehaviour
{
    public Transform[] views;

    public GameObject[] PanelesInfo;
    public GameObject[] BotonesVolver;


    public float transitionSpeed;

    public Transform currentView;


    void Start()
    {
        currentView = views[0];   
    }

    
    void Update()
    {

        if (currentView == views[0] && Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //currentView = views[4];
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[1];
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                PanelesInfo[0].SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(BotonesVolver[0]);
            }
        }

        else if (currentView == views[1] && Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[0];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[2];
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                PanelesInfo[1].SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(BotonesVolver[1]);
            }
        }

        else if (currentView == views[2] && Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[1];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[3];
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                PanelesInfo[2].SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(BotonesVolver[2]);
            }
        }

        else if (currentView == views[3] && Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[2];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                currentView = views[4];
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                PanelesInfo[3].SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(BotonesVolver[3]);
            }
        }

        else if (currentView == views[4] && Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                currentView = views[3];
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                //currentView = views[0];
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                PanelesInfo[4].SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(BotonesVolver[4]);
            }
        }
    }

    public void ClosePaneles()
    {
        Time.timeScale = 1;
        PanelesInfo[0].SetActive(false);
        PanelesInfo[1].SetActive(false);
        PanelesInfo[2].SetActive(false);
        PanelesInfo[3].SetActive(false);
        PanelesInfo[4].SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void LateUpdate()
    {
        
        transform.position=Vector3.Lerp(transform.position,currentView.position,Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
            Mathf.Lerp(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x,
            Time.deltaTime * transitionSpeed),

            Mathf.Lerp(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y,
            Time.deltaTime * transitionSpeed),

            Mathf.Lerp(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z,
            Time.deltaTime * transitionSpeed)

            );

        transform.eulerAngles = currentAngle;
    }
}

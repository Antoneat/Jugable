using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSuccubo : MonoBehaviour
{

    public GameObject Sucubo;
    public GameObject shopUI;

    bool isAdentro;
    bool bienAdentro;

    private void Start()
    {
        Sucubo.SetActive(false);
        shopUI.SetActive(false);
        isAdentro = false;
        bienAdentro = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isAdentro)
            {
                if(bienAdentro)
                {
                    salirTienda();
                 //   isAdentro=false;
                    bienAdentro = false;
                }
                else
                {
                    entrarTienda();
                    Debug.Log("adentro");
                    bienAdentro = true;
                }   
            }
        }

    } 


    void entrarTienda()
    {
        shopUI.SetActive(true);
    }
    void salirTienda()
    {
        shopUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            isAdentro = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            isAdentro = false;

        }
    }

}

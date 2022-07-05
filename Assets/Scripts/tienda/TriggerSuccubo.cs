using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSuccubo : MonoBehaviour
{

    public GameObject Sucubo;
    public GameObject shopUI;
    private void Start()
    {
        Sucubo.SetActive(false);
       shopUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sucubo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sucubo.SetActive(false);
        }
    }

    public void SuccIn()
    {
        Sucubo.SetActive(true);
        shopUI.SetActive(false);
    }

    public void SuccOut()
    {
            Sucubo.SetActive(false);
            shopUI.SetActive(true);
    }

    public void Exit()
    {
        Sucubo.SetActive(false);
        shopUI.SetActive(false);
    }
}

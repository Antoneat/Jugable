using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSuccubo : MonoBehaviour
{

    public GameObject Sucubo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sucubo.SetActive(true);
        }
    }

    public void Out()
    {
            Sucubo.SetActive(false);
    }
}

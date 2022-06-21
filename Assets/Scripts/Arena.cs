using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public StateManager SM;

    void Start()
    {

       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SM.ps = PlayerState.Quemado;
        }
    }
}

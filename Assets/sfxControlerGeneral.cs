using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sfxControlerGeneral : MonoBehaviour
{
    public ObjetosRompibles ObjetosRompibles;




    public AudioSource sfxDestruido;

    void Start()
    {
        
    }

    void Update()
    {
        if(ObjetosRompibles.vida <= 0)
        {
            sfxDestruido.Play();
        }
    }
}

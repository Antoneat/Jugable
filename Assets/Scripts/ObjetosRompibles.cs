using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ObjetosRompibles : MonoBehaviour
{
    public Player plyr;
    public float vida = 1;

    public float cantidadDeAlmas;
    public float cantidadDeVida;
    public bool isDead = false;
    public LifeBar lifebar;

    public AudioSource sfxDestruido;
    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        lifebar = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().lifeBar;
        //sfxDestruido = GetComponent<AudioSource>();
    }

    void Update()
    {
        Muerte();

    }

    private void Muerte()
    {
        if (vida <= 0)
        {
            if (!isDead)
            {
                plyr.almasTotal += cantidadDeAlmas;
                plyr.actualvida += cantidadDeVida;
                lifebar.SetVida(plyr.actualvida);
                isDead = true;
            }
            Destroy(gameObject,0.3f);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AtaqueUno"))
        {
            vida -= plyr.AttackDmgUno;
            sfxDestruido.Play();
        }

        if (collider.gameObject.CompareTag("AtaqueDos"))
        {
            vida -= plyr.AttackDmgDos;
            sfxDestruido.Play();
        }

        if (collider.gameObject.CompareTag("AtaqueTres"))
        {
            vida -= plyr.AttackDmgTres;
            sfxDestruido.Play();
        }

        if (collider.gameObject.CompareTag("AtaqueCargado"))
        {
            vida -= plyr.AttackDmgCargado;
            sfxDestruido.Play();
        }

        if (collider.gameObject.CompareTag("Enemigo"))
        {
            vida -= 1;
            sfxDestruido.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
   
    if (collision.gameObject.CompareTag("Enemigo"))
    {
        vida -= 1;
        sfxDestruido.Play();
    }
    
    }
}

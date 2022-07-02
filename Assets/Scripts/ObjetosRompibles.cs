using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosRompibles : MonoBehaviour
{
    public Player plyr;
    public int vida = 1;

    public float cantidadDeAlmas;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        Muerte();
    }

    private void Muerte()
    {
        if (vida <= 0)
        {
            plyr.almasTotal += cantidadDeAlmas;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AtaqueUno")) vida -= plyr.AttackDmgUno;

        if (collider.gameObject.CompareTag("AtaqueDos")) vida -= plyr.AttackDmgDos;

        if (collider.gameObject.CompareTag("AtaqueTres")) vida -= plyr.AttackDmgTres;

        if (collider.gameObject.CompareTag("AtaqueCargado")) vida -= plyr.AttackDmgCargado;
    }
}

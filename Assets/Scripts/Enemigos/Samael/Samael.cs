using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Samael : MonoBehaviour
{
    [Header("Vida")]
    public float vida;
    public float maxVida = 100f;

    [Header("Cosas generales")]
    public GameObject rangoDeDeteccion;
    public bool dentroDeRangoDeteccion;
    public bool enHabilidad;

    [Header("Juego Sucio")]     // 1ra habilidad
    public bool primeraHabilidad;
    public Transform ultimaPosPlayer;
    public float velDeImpulso = 7f;

    [Header("Ataque Basico")]     // 2da habilidad
    public bool segundaHabilidad;
    public float samaelBasico12DMG = 3.5f;   // hacer interaccion en el script player.
    public GameObject samaelBasico12GO;  // hacer GO en inspector.
    public float samaelBasico3DMG = 5f;   // hacer interaccion en el script player.
    public GameObject samaelBasico3GO;  // hacer GO en inspector.

    [Header("Ataque Cargado")]     // 3ra habilidad
    public bool terceraHabilidad;
    public float samaelCargadoDMG = 6.5f;   // hacer interaccion en el script player.
    public GameObject samaelCargadoGO;  // PONER dentro del script del player, si choca en este trigger, que quede stuneado.

    [Header("Invocacion")]      // 4ta habilidad


    [Header("Dia Del Juicio")]      // 5ta habilidad
    public bool diaDelJuicio;
    public bool diaDelJuicioEND;    // Cuando termine la habilidad
    public float coolDownDiaDelJuicio;  // Cooldown para que vuelva a usar la habilidad

    [Header("Armamento")]       // 6ta habilidad

    [Header("Componenetes")]
    public Player plyr;
    public StateManager stateManager;
    public Rigidbody rb;
    public NavMeshAgent agent;


    void Start()
    {
        vida = maxVida;
        stateManager = GameObject.FindGameObjectWithTag("Player").GetComponent<StateManager>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1f;
        enHabilidad = false;
        dentroDeRangoDeteccion = false;
        diaDelJuicio = false;
        diaDelJuicioEND = false;
    }


    void Update()
    {
        if (!enHabilidad && stateManager.ps == PlayerState.Normal)
        {
            agent.destination = ultimaPosPlayer.position;
        }
        else if (stateManager.ps == PlayerState.Stun && primeraHabilidad == false && enHabilidad == false)      // Juego Sucio 1ra habilidad
        {
            StartCoroutine(JuegoSucio());
        }
        else if (dentroDeRangoDeteccion == true && segundaHabilidad == false && enHabilidad == false)       // Ataque Basico 2da habilidad
        {
            StartCoroutine(AtaqueBasico());
        }
        else if (dentroDeRangoDeteccion == false && terceraHabilidad == false && enHabilidad == false && stateManager.ps == PlayerState.Normal)     // Ataque Cargado 3ra habilidad
        {
            StartCoroutine(AtaqueCargado());
        }
        else if (vida <= 25 && diaDelJuicio == false && coolDownDiaDelJuicio == 0 && enHabilidad == false)  // Dia del juicio 5ta habilidad
        {
            StartCoroutine(DiaDelJuicioStart());
        }

        if (diaDelJuicioEND)
        {
            StartCoroutine(DiaDelJuicioEnd());
        }
        else return;

        if(coolDownDiaDelJuicio > 0)
        {
            coolDownDiaDelJuicio -= Time.deltaTime;
        }
    }

    IEnumerator JuegoSucio() // 1ra Habilidad
    {
        enHabilidad = true;
        primeraHabilidad = true;
        agent.destination = ultimaPosPlayer.position;
        Debug.Log("Samael. " + ultimaPosPlayer);
        agent.speed = 0f;
        Debug.Log("Samael. Quieto");
        yield return new WaitForSecondsRealtime(3.5f);
        agent.speed = 2f;
        Debug.Log("Samael. Moviendose");
        rb.AddForce(Vector3.forward * velDeImpulso * Time.deltaTime, ForceMode.Impulse);
        Debug.Log("Samael. Impulsandose");
        primeraHabilidad = false;
        yield return new WaitForSecondsRealtime(2f);
        agent.speed = 1f;
        enHabilidad = false;
        yield break;
    }

    IEnumerator AtaqueBasico() // 2da Habilidad
    {
        enHabilidad = true;
        segundaHabilidad = true;
        yield return new WaitForSecondsRealtime(0.65f);
        samaelBasico12GO.SetActive(true);
        yield return new WaitForSecondsRealtime(0.35f);
        samaelBasico12GO.SetActive(false);
        yield return new WaitForSecondsRealtime(0.65f);
        samaelBasico12GO.SetActive(true);
        yield return new WaitForSecondsRealtime(0.35f);
        samaelBasico12GO.SetActive(false);
        yield return new WaitForSecondsRealtime(0.65f);
        agent.speed = 0f;
        samaelBasico3GO.SetActive(true); // escribir en script de player, si esta en el rango del golpe que quede stuned
        yield return new WaitForSecondsRealtime(0.35f);
        agent.speed = 1f;
        enHabilidad = false;
        segundaHabilidad = false;
        yield break;
    }

    IEnumerator AtaqueCargado() // 3ra habilidad
    {
        enHabilidad = true;
        terceraHabilidad = true;
        // animacion de proceso de salto
        yield return new WaitForSecondsRealtime(4.5f);
        rb.AddForce(Vector3.up * velDeImpulso * Time.deltaTime, ForceMode.Impulse);
        rb.useGravity = false;
        yield return new WaitForSecondsRealtime(1f);
        transform.position = new Vector3(0,10,0); // Ponerle la posicion central del centro de batalla
        samaelCargadoGO.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        rb.AddForce(-Vector3.up * velDeImpulso * Time.deltaTime, ForceMode.Impulse);
        yield return new WaitForSecondsRealtime(0.5f);
        samaelCargadoGO.SetActive(false);
        enHabilidad = false;
        terceraHabilidad = false;
        yield break;
    }



    IEnumerator DiaDelJuicioStart() // 5ta habilidad start
    {
        enHabilidad = true;
        diaDelJuicio = true;
        yield return new WaitForSeconds(5f);
        StartCoroutine(Armamento());
        yield break;
    }
    IEnumerator Armamento() // 6ta habilidad 
    {

        diaDelJuicioEND = true;
        yield break;
    }

    IEnumerator DiaDelJuicioEnd() // 5ta habilidad end
    {
        agent.speed = 0;
        // animacion de descanso;
        yield return new WaitForSeconds(6f);
        coolDownDiaDelJuicio = 30f;
        agent.speed = 1;
        yield break;
    }
}

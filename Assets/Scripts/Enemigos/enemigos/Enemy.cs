using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Player plyr;
    public StateManager SM;
    public StateManagerEnemies SME;
    public enemyPatrol eP;

    [Header("Vida")]
    public float vida;
    public bool dead;

    [Header("AtaqueBasico")]
    public float ataqueNormalDMG;
    public GameObject basicoGO;
    public GameObject atkBTxt;

    [Header("Mordisco")]
    public float mordiscoDMG;
    public GameObject mordiscoGO;
    public GameObject mordiscoTxt;

    [Header("Extra")]
    [SerializeField] private float knockbackStrength;

    public bool coPlay; 

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SM = GameObject.FindGameObjectWithTag("Player").GetComponent<StateManager>();
        
        //ObjetoASeguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        dead = false;
        basicoGO.SetActive(false);
        mordiscoGO.SetActive(false);

       // atkBTxt.SetActive(false);
        //mordiscoTxt.SetActive(false);

        coPlay = false;
    }

    void Update()
    {
        Muerte();
    }

    private void Muerte()
    {
        if (vida <= 0)
        {
            plyr.killedEnemy = true;
            plyr.dashIMG.SetActive(true);
            plyr.actualvida += 10;
            plyr.almas += 10;
            plyr.enemigosDerrotados++;
            dead = true;
            Destroy(gameObject);
        }
    }

    public void ChooseAtk()
    {
        if (SM.ps == PlayerState.Normal && coPlay == false || SM.ps == PlayerState.Stun && coPlay == false || SM.ps == PlayerState.Sangrado && coPlay == false)
        {
            StartCoroutine(AtaqueBasico());
        }
        else if (SM.ps == PlayerState.Quemado && coPlay == false)
        {
            StartCoroutine(Mordisco());
        }
        
    }

    IEnumerator AtaqueBasico()
    {
        coPlay = true;
        eP.agent.isStopped = true;
        yield return new WaitForSecondsRealtime(1f);
        eP.agent.isStopped = false;
        basicoGO.SetActive(true);

        //anim empieza

        yield return new WaitForSecondsRealtime(2f);
        basicoGO.SetActive(false);

        //anim termina

        yield return new WaitForSecondsRealtime(1f);
        coPlay = false;
        yield break;
    }

    IEnumerator Mordisco()
    {
        coPlay = true;
        eP.agent.isStopped = true;
        yield return new WaitForSecondsRealtime(1.5f);
        eP.agent.isStopped = false;
        mordiscoGO.SetActive(true);

        //anim empieza

        //SM.ps = PlayerState.Sangrado;
        yield return new WaitForSecondsRealtime(2f);
        mordiscoGO.SetActive(false);

        //anim termina

        yield return new WaitForSecondsRealtime(1f);
        coPlay = false;
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FueraDelMundo")) Destroy(gameObject); // Si toca los colliders de FueraDelMundo, se destruye.
    }

    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();

        if(rb != null)
        {
            Vector3 direction = collider.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }

        if (collider.gameObject.CompareTag("AtaqueUno")) vida -= plyr.AttackDmgUno; // Baja la vida del enemigo acorde con el valor que se puso en el ataque.

        if (collider.gameObject.CompareTag("AtaqueDos")) vida -= plyr.AttackDmgDos; // Lo de arriba x2.

        if (collider.gameObject.CompareTag("AtaqueTres")) vida -= plyr.AttackDmgTres; // Lo de arriba x3.

        if (collider.gameObject.CompareTag("BasicoUpgraded")) vida -= 1;

        if (collider.gameObject.CompareTag("AtaqueCargado"))
        {
            if (plyr.cargadoAzul == false)
            {
                vida -= plyr.AttackDmgCargado;
            }
            else if (plyr.cargadoAzul == true)
            {
                vida -= plyr.AttackDmgCargado;
                SME.es = EnemyState.Quemado;
            }
        }
    }
}

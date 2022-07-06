using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy2 : MonoBehaviour
{

    public Player plyr;
    public StateManager SM;
    public StateManagerEnemies SME;
    public enemyPatrol2 eP2;

    public float proyectileSpeed = 8;

    [Header("Vida")]
    public float vida;
    public bool dead;

    [Header("AtaqueBasico")]
    public float atkbasDMG;
    public GameObject atkbasGO;
    public GameObject atkBTxt;

    [Header("GolpeAlPiso")]
    public float golpeDMG;
    public GameObject golpeGO;
    public GameObject golpeTxt;

    [Header("Rafaga")]
    public float rafagaDMG;
    public GameObject rafagaGO;
    public GameObject rafagaTxt;

    [Header("Extra")]
    [SerializeField] private float knockbackStrength;
    public Vector3 playerpos;

    public bool coPlay;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SM = GameObject.FindGameObjectWithTag("Player").GetComponent<StateManager>();

        dead = false;

        atkbasGO.SetActive(false);
        golpeGO.SetActive(false);
        rafagaGO.SetActive(false);

        //atkBTxt.SetActive(false);
        //golpeTxt.SetActive(false);
       // rafagaTxt.SetActive(false);

        coPlay = false;
    }

    void Update()
    {
       
        Muerte();
        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;
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

    public void ChooseAtk2()
    {
        if (coPlay == false && SM.ps == PlayerState.Normal && eP2.playerDistance < eP2.atkRange || coPlay == false &&  SM.ps == PlayerState.Sangrado && eP2.playerDistance < eP2.atkRange || coPlay == false &&  SM.ps == PlayerState.Quemado && eP2.playerDistance < eP2.atkRange)
        {
            StartCoroutine(AtaqueBasico());
        }
        else if (coPlay == false && SM.ps == PlayerState.Stun && eP2.playerDistance < eP2.atkRange)
        {
            StartCoroutine(GolpeAlPiso());
        }
        else if (coPlay == false && eP2.playerDistance > eP2.atkRange && eP2.playerDistance < eP2.awareAI)
        {
            StartCoroutine(Rafaga());
        }

    }

    IEnumerator AtaqueBasico()
    {
        Debug.Log("ataque bas");
        if (!atkbasGO.activeSelf)
        {
            coPlay = true;
            eP2.agent.isStopped = true;
            yield return new WaitForSecondsRealtime(1.5f);

            atkbasGO.transform.position = transform.position;
            atkbasGO.transform.parent = null;
            atkbasGO.SetActive(true);

            //atkBTxt.SetActive(true); ANIMACION GO
            float step = proyectileSpeed * Time.deltaTime; // calculate distance to move

            Vector3 playePos = playerpos;
            Vector3 originPos = transform.position;

            float timer = 4;
            while (timer >= 0)
            {
                timer -= Time.deltaTime;
                atkbasGO.transform.position = Vector3.MoveTowards(originPos, playePos, step);
                yield return null;
            }

            eP2.agent.isStopped = false;
            atkbasGO.SetActive(false);
            atkbasGO.transform.parent = transform;
            //atkBTxt.SetActive(true); FUNA LA ANIMACION
            yield return new WaitForSecondsRealtime(1f);
            coPlay = false;
            yield break;
        }
    }

        IEnumerator GolpeAlPiso()
    {

        if (!golpeGO.activeSelf)
        {
            coPlay = true;
            eP2.agent.isStopped = true;
            yield return new WaitForSecondsRealtime(3f);

            golpeGO.transform.position = transform.position;
            golpeGO.transform.parent = null;
            golpeGO.SetActive(true);

            golpeGO.transform.position = playerpos;
           

            //anim empieza

            eP2.agent.isStopped = false;
            yield return new WaitForSecondsRealtime(1f);
            golpeGO.SetActive(false);
            atkbasGO.transform.parent = transform;

            // anim termina

            yield return new WaitForSecondsRealtime(1f);
            coPlay = false;
            yield break;
        }
    }

    IEnumerator Rafaga()
    {

        if (!rafagaGO.activeSelf)
        {
            coPlay = true;
            eP2.agent.isStopped = true;
            yield return new WaitForSecondsRealtime(1f);
          
            rafagaGO.transform.position = transform.position;
            rafagaGO.transform.parent = null;
            rafagaGO.SetActive(true);

            //anim empieza

            float step = proyectileSpeed * Time.deltaTime; // calculate distance to move

            Vector3 playePos = playerpos;
            Vector3 originPos = transform.position;

            float timer = 2;

            while (timer >= 0)
            {
                timer -= Time.deltaTime;
                rafagaGO.transform.position = Vector3.MoveTowards(originPos, playePos, step);
                yield return null;
            }

  
            eP2.agent.isStopped = false;
            rafagaGO.SetActive(false);
            atkbasGO.transform.parent = transform;

            //anim termina
            yield return new WaitForSecondsRealtime(1f);
            coPlay = false;
            yield break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FueraDelMundo")) Destroy(gameObject); // Si toca los colliders de FueraDelMundo, se destruye.
    }

    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();

        if (rb != null)
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

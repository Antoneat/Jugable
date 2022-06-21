using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Player plyr;

    public GameObject Hand1;
    public GameObject Hand2;

    public GameObject portalA;
    public GameObject portalB;
    public GameObject portalC;
    public GameObject portalD;

    public HandsPatrol hp;
    public HandsPatrol2 hp2;

    public float actualvida;
    public float maxVida=40;

   // public Transform teleport1;
    //public Transform teleport2;

    public Transform pointa;
    public Transform pointb;

    public Transform pointc;
    public Transform pointd;

    public GameObject onda;
    public bool isCreated;
    public bool isDestroyed;

    public bool vulnerable;
    bool loop;

    public bool coPlay;
    
    void Start()
    {
       
        actualvida = maxVida;
        vulnerable = false;
        loop = true;
        isCreated=false;
        coPlay = false; 
        //isDestroyed=false;

        portalA.SetActive(false);
        portalB.SetActive(false);
        portalC.SetActive(false);
        portalD.SetActive(false);
    }


    void Update()
    {
        if(actualvida >=20)
        {
            Sequence1();
            portalA.SetActive(false);
            portalB.SetActive(false);
            portalC.SetActive(false);
            portalD.SetActive(false);
        }
        else if(actualvida <20)
        {
            Sequence2();
            portalA.SetActive(true);
            portalB.SetActive(true);
            portalC.SetActive(true);
            portalD.SetActive(true);
        }
    }

    private void Sequence1()
    {
        StartCoroutine(Seq());
    }
    private void Sequence2()
    {
        StartCoroutine(Seq2());
    }

    private IEnumerator Seq()
    {
        while (loop ==true)
        {
            if(coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico1());

            }
            
            yield return new WaitForSecondsRealtime(0.7f);
            
            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico2());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Especial());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico3());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico4());
            }
           
            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico2());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Especial());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico1());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico3());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico5());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Especial());
            }

            yield return new WaitForSecondsRealtime(0.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico6());
            }

            yield return new WaitForSecondsRealtime(0.7f);
        }
        yield  break;
    }
    private IEnumerator Seq2()
    {
        while (loop == true)
        {
            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico1());

            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico2());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Especial());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico3());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico4());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico2());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Especial());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico1());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico3());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico5());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Especial());
            }

            yield return new WaitForSecondsRealtime(1.7f);

            if (coPlay == false)
            {
                yield return StartCoroutine(Ataquebasico6());
            }

            yield return new WaitForSecondsRealtime(1.7f);
        }
        yield break;
    }


    IEnumerator Ataquebasico1()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(2.5f);
        hp.GotoNextPoint1();
        yield return new WaitForSecondsRealtime(4f);
        hp.GotoNextPoint2();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }

    IEnumerator Ataquebasico2()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(2.5f);
            hp2.GotoNextPoint1();
            yield return new WaitForSecondsRealtime(1f);
            hp2.GotoNextPoint2();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }

    IEnumerator Ataquebasico3()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(2.5f);
        hp2.GotoNextPoint3();
        yield return new WaitForSecondsRealtime(1f);
        hp2.GotoNextPoint4();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }

    IEnumerator Ataquebasico4()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(2.5f);
        hp.GotoNextPoint1();
        yield return new WaitForSecondsRealtime(1f);
        hp.GotoNextPoint2();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }

    IEnumerator Ataquebasico5()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(2.5f);
        hp.GotoNextPoint2();
        yield return new WaitForSecondsRealtime(1f);
        hp.GotoNextPoint1();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }

    IEnumerator Ataquebasico6()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(2.5f);
        hp.GotoNextPoint4();
        yield return new WaitForSecondsRealtime(1f);
        hp.GotoNextPoint3();
        vulnerable = true;
        yield return new WaitForSecondsRealtime(4f);
        vulnerable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }

  

    IEnumerator Especial()
    {
        coPlay = true;
        GotoPointA();
        yield return new WaitForSecondsRealtime(0.5f);
        GotoPointB();
        yield return new WaitForSecondsRealtime(0.5f);
        OndaExpansiva();
        yield return new WaitForSecondsRealtime(2f);
        vulnerable = true;
        hp.agent.isStopped = true;
        hp2.agent.isStopped = true;
        yield return new WaitForSecondsRealtime(5f);
        hp.agent.isStopped = false;
        hp2.agent.isStopped = false;
        vulnerable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }


    public void GotoPointA()
    {
        hp.agent.destination = pointa.position;
        hp2.agent.destination = pointb.position;
    }

    public void GotoPointB()
    {
        hp.agent.destination = pointc.position;
        hp2.agent.destination = pointd.position;
    }

    void OndaExpansiva()
    {
       
        if (isCreated==false)
        {
          Vector3 pos = new Vector3(-1,1,0);
          Instantiate(onda, pos, Quaternion.identity);
          Destroy(GameObject.Find("onda(Clone)"),2);
          isCreated = true;
        }
    }




}

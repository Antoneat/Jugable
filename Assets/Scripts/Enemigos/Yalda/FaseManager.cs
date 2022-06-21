using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseManager : MonoBehaviour
{
    public Hands h;
    public Yaldabaoth y;
    public GameObject Yaldabaoth;
    public GameObject Hands;

    public Player plyr;

    public bool coPlay; 

    void Start()
    {
        Yaldabaoth.SetActive(false);
        Hands.SetActive(true);
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        coPlay = false;
    }

  
    void Update()
    {
        ChangeFase();

    }

    void ChangeFase()
    {
        if (h.actualvida <= 0)
        {
            Hands.SetActive(false);
            Yaldabaoth.SetActive(true);
            StartCoroutine(HandsRegen());
        }
     
        if (y.actualvida <= 0 && h.actualvida == h.maxVida)
        {
            Yaldabaoth.SetActive(false);
            Hands.SetActive(true);
            StartCoroutine(YaldaRegen());
        }
        else if (y.actualvida <= 0 && h.actualvida < h.maxVida)
        {
            plyr.actualvida += 10;
            Destroy(gameObject);
        }
    }


    IEnumerator HandsRegen()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(80f);
        h.actualvida = h.maxVida;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }
    IEnumerator YaldaRegen()
    {
        coPlay = true;
        yield return new WaitForSecondsRealtime(160f);
        y.actualvida = y.maxVida;
        yield return new WaitForSecondsRealtime(0.5f);
        coPlay = false;
        yield break;
    }
}

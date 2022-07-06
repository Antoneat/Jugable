using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAttackCharged : MonoBehaviour
{
    public int i;
    SphereCollider sphereColl;

    //Player plyr;

    void OnEnable()
    {
        StartCoroutine(Action());
        sphereColl = GetComponent<SphereCollider>();

        //plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        Debug.Log(i);
        if (i == 2)
        {
            //plyr.buff = true;
            enabled = false;
        }
    }

    IEnumerator Action()
    {
        //plyr.speed = 0;
        for (i = 0; i < 3; i++)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            sphereColl.enabled = true;
            yield return new WaitForSecondsRealtime(1f);
            sphereColl.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAttackUpgraded : MonoBehaviour
{
    int i;
    BoxCollider boxColl;

    void Start()
    {
        StartCoroutine(Action());
        boxColl = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (i == 2)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Action()
    {
        for (i = 0; i < 2; i++)
        {
            yield return new WaitForSecondsRealtime(1f);
            boxColl.enabled = false;
            yield return new WaitForSecondsRealtime(0.1f);
            boxColl.enabled = true;
        }
    }
}

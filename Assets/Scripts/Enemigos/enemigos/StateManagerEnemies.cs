using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Normal, Quemado};
public class StateManagerEnemies : MonoBehaviour
{
    public EnemyState es;
    Enemy enmy;
    Enemy2 enmy2;

    public float dmgTick; // Damage each tick
    public float timeXTick; // Time in seconds each tick of damage
    public int totalTicks; // how many seconds ( ticks )  damage each tick

    public int fireTicks;

    IEnumerator normal;
    IEnumerator onFire;

    bool normalrunning;
    bool onFirerunning;

    void Start()
    {
        normal = Normal();
        onFire = OnFire();

        es = EnemyState.Normal;
        enmy = GetComponent<Enemy>();
        enmy2 = GetComponent<Enemy2>();
    }


    void Update()
    {
        Stados();
    }


    void Stados()
    {
        switch (es)
        {
            case EnemyState.Normal:
                if (!normalrunning)
                {
                    StartCoroutine(Normal());
                }

                break;

            case EnemyState.Quemado:

                if (!onFirerunning)
                {
                    StartCoroutine(OnFire());
                    fireTicks = 0;
                }

                break;
        }
    }

    IEnumerator Normal()
    {
        normalrunning = true;
        yield return new WaitForSecondsRealtime(0.1f);
        normalrunning = false;
        yield break;
    }

    IEnumerator OnFire()
    {
        onFirerunning = true;
        yield return new WaitForSecondsRealtime(0.5f);

        dmgTick = 0.5f;
        timeXTick = 1;
        totalTicks = 3;

        int totalTicksTemp = totalTicks;

        while (fireTicks < totalTicksTemp)
        {
            fireTicks++;
            enmy.vida -= dmgTick;  // recive damage
            enmy2.vida -= dmgTick;  // recive damage
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);
        fireTicks = 0;
        es = EnemyState.Normal;
        onFirerunning = false;
        yield return null;
    }
}

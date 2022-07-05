using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Normal, Quemado, Sangrado, Stun };
public class StateManager : MonoBehaviour
{
    public PlayerState ps;
    Player Pl;

    public float dmgTick; // Damage each tick
    public float timeXTick; // Time in seconds each tick of damage
    public int totalTicks; // how many seconds ( ticks )  damage each tick
    IEnumerator normal;
    IEnumerator onFire; 
    IEnumerator sangrado; 
    IEnumerator stuneado;
    bool normalrunning;
    bool onFirerunning;
    bool sangradorunning;
    bool stuneadorunning;

    void Start()
    {
        normal = Normal();
        onFire= OnFire();
        sangrado = Sangrando();
        stuneado= Stuneado();

        ps = PlayerState.Normal;
       Pl=GetComponent<Player>();   
    }


    void Update()
    {
        Stados();
    }

    IEnumerator Normal()
    {
       normalrunning = true;
        yield return new WaitForSecondsRealtime(0.1f);
        normalrunning = false;
        yield break;
    }

    void Stados()
    {
        switch (ps)
        {
            case PlayerState.Normal:
                if ( !normalrunning )
                {
                    StartCoroutine(normal);
                }
                
                break;

            case PlayerState.Quemado:
                if (!onFirerunning)
                {
                    StartCoroutine(onFire);
                }
               
                break;

            case PlayerState.Sangrado:
                if (!sangradorunning)
                {
                    StartCoroutine(sangrado);
                }
                
                break;

            case PlayerState.Stun:
                if (!stuneadorunning)
                {
                    StartCoroutine(stuneado);
                }
               
                break;
        }
    }

    IEnumerator OnFire()
    {
        onFirerunning = true;
        dmgTick = 2;
        timeXTick = 2;
        totalTicks = 4;

        int ticks = 0;
        int totalTicksTemp = totalTicks;

        while (ticks < totalTicksTemp)
        {
            ticks++;
            Pl.actualvida -= dmgTick;  // Player recive damage
           // Pl.speed -= 4;
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
            
            yield return null;
        }
        ps = PlayerState.Normal;
        onFirerunning = false;
    }

    IEnumerator Sangrando()
    {
        sangradorunning = true;
        dmgTick = 4;
        timeXTick = 4;
        totalTicks = 3;

        int ticks = 0;
        int totalTicksTemp = totalTicks;

        while (ticks < totalTicksTemp)
        {
            ticks++;
            Pl.actualvida -= dmgTick;  // Player recive damage
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
          
            yield return null;

        }
        sangradorunning = false;
        ps = PlayerState.Normal;
    }

    IEnumerator Stuneado()
    {
        stuneadorunning = true;
        Pl.speed = 0;
        yield return new WaitForSecondsRealtime(4f);
        sangradorunning = false;
        ps = PlayerState.Normal;
        yield return null;
    }
}

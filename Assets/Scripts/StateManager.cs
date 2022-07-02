using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Normal, Quemado, Sangrado, Stun };
public class StateManager : MonoBehaviour
{
    public PlayerState ps;
    public Player Pl;
    public LifeBar lifebar;

    public bool dos;


    public float dmgTick; // Damage each tick
    public float timeXTick; // Time in seconds each tick of damage
    public int totalTicks; // how many seconds ( ticks )  damage each tick

    void Start()
    {
        Pl = GetComponent<Player>();
        ps = PlayerState.Normal;
    }


    void Update()
    {
        Stados();
        if (dos == true) Pl.speed = 150;
    }

    IEnumerator Normal()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        yield break;
    }

    void Stados()
    {
        switch (ps)
        {
            case PlayerState.Normal:
                StartCoroutine(Normal());
                break;

            case PlayerState.Quemado:
                if(dos == false)
                StartCoroutine(OnFire());
                break;

            case PlayerState.Sangrado:
                StartCoroutine(Sangrando());
                break;

            case PlayerState.Stun:
                StartCoroutine(Stuneado());
                break;
        }
    }

    IEnumerator OnFire()
    {
        dos = true;

        dmgTick = 0.5f;
        timeXTick = 1f;
        totalTicks = 6;

        int totalTicksTemp = totalTicks;

        for (int ticks = 0; ticks < totalTicksTemp; ticks++)
        {
            Pl.actualvida -= dmgTick;  // Player recive damage
            lifebar.SetVida(Pl.actualvida);
            ticks++;
            Debug.Log(ticks);
            Debug.Log(totalTicksTemp);
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
        }
        yield return new WaitForSecondsRealtime(0.5f);
        ps = PlayerState.Normal;
        dos = false;
        yield break;
    }

    IEnumerator Sangrando()
    {

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
            ps = PlayerState.Normal;
            yield break;
            
        }
        yield break;

    }

    IEnumerator Stuneado()
    {
        Pl.speed = 0;
        yield return new WaitForSecondsRealtime(4f);
        ps = PlayerState.Normal;
        yield break;
    }
}

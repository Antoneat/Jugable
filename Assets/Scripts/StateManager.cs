using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Normal, Quemado, Sangrado, Stun };
public class StateManager : MonoBehaviour
{
    public PlayerState ps;
    Player Pl;
    public Animator anim;

    public float dmgTick; // Damage each tick
    public float timeXTick; // Time in seconds each tick of damage
    public int totalTicks; // how many seconds ( ticks )  damage each tick

    public int fireTicks;
    public int bleedTicks;

    IEnumerator normal;
    IEnumerator onFire; 
    IEnumerator sangrado; 
    IEnumerator stuneado;

    bool normalrunning;
    bool onFirerunning;
    bool sangradorunning;
    bool stuneadorunning;


    public LifeBar lifebar;
    public bool speedless;

    void Start()
    {
        normal = Normal();
        onFire= OnFire();
        sangrado = Sangrando();
        stuneado= Stuneado();

        ps = PlayerState.Normal;
        Pl = GetComponent<Player>();   
    }


    void Update()
    {
        Stados();
        if (speedless == true) Pl.speed = 150;
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
                    StartCoroutine(Normal());
                }
                
                break;

            case PlayerState.Quemado:
               
                if (!onFirerunning)
                {
                    StartCoroutine(OnFire());
                    fireTicks = 0;
                }
               
                break;

            case PlayerState.Sangrado:
                if (!sangradorunning)
                {
                    StartCoroutine(Sangrando());
                    bleedTicks = 0;
                }
                
                break;

            case PlayerState.Stun:
                if (!stuneadorunning)
                {
                    StartCoroutine(Stuneado());
                }
               
                break;
        }
    }

    IEnumerator OnFire()
    {
        anim.speed = 0.5f;
        speedless = true;
        onFirerunning = true;
        yield return new WaitForSecondsRealtime(0.5f);

        dmgTick = 0.5f;
        timeXTick = 1;
        totalTicks = 3;

        int totalTicksTemp = totalTicks;

        while (fireTicks < totalTicksTemp)
        {
            fireTicks++;
            Pl.actualvida -= dmgTick;  // Player recive damage
            lifebar.SetVida(Pl.actualvida); //aaaaa
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);
        fireTicks = 0;
        ps = PlayerState.Normal;
        speedless = false;
        onFirerunning = false;
        anim.speed = 1;
        yield return null;
    }

    IEnumerator Sangrando()
    {
        sangradorunning = true;
        dmgTick = 0.5f;
        timeXTick = 1;
        totalTicks = 6;

        int totalTicksTemp = totalTicks;

        while (bleedTicks < totalTicksTemp)
        {
            bleedTicks++;
            Pl.actualvida -= dmgTick;  // Player recive damage
            lifebar.SetVida(Pl.actualvida);
            yield return new WaitForSecondsRealtime(timeXTick);  // wait second
          
            yield return null;

        }
        yield return new WaitForSecondsRealtime(0.5f);
        bleedTicks = 0;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] puertas;
    public GameObject[] spawnPoints;    // Puntos de spawn.
    public GameObject[] enemies;    // Enemigos que spawneara.
    public GameObject activador;
    public int waveCount;
    public int wave;    // Oleada actual.
    public int enemyType;   // Tipo de enemigo 0=Buscador 1=Verdugo.
    public int enemiesSpawned;  // Cantidad de enemigos spawneados.
    public bool spawning;   // Spawneando.
    public bool waveActivator;  // Active el spawning de las oleadas;
    public bool doorActivator;  // Active el collider de las puertas;

    [Header("Enemies Stuff")]
    public int defeatedEnemies;
    public int enemiesCounterAnt;
    public int enemiesCounter;

    public Player plyr;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        waveCount = 3;
        wave = 0;
        spawning = false;
        waveActivator = false;
        doorActivator = false;
        enemiesSpawned = 0;
        defeatedEnemies = 0;
    }

    void Update()
    {
        if (spawning == false && enemiesSpawned == plyr.enemigosDerrotados && waveActivator == true && doorActivator == true)
        {
            StartCoroutine(SpawnWave(waveCount));
        }

        if (doorActivator == true)
        {
            puertas[0].SetActive(true);
            puertas[1].SetActive(true);
            puertas[2].SetActive(true);
        }
    }

    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;
        doorActivator = true;

        yield return new WaitForSeconds(4f);

        for (int i = 0; i < waveC; i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(2f);
        }

        wave += 1;
        spawning = false;
        if (wave == 3)
        {
            FinishFloorWave();
        }
        yield break;
    }

    void SpawnEnemy(int wave)
    {
        int spawnPos = Random.Range(0, 4);

        if (wave >= 1)
        {
            enemyType = Random.Range(0, 2);
        }

        Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
        enemiesSpawned += 1;
    }

    public void FinishFloorWave()
    {
        enemiesSpawned = 0;
        plyr.enemigosDerrotados = 0;
        waveActivator = false;
        doorActivator = false;
        puertas[0].SetActive(false);
        puertas[1].SetActive(false);
        puertas[2].SetActive(false);
        activador.SetActive(false);
    }
}

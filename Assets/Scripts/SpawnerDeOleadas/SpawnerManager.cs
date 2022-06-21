using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] spawnPoints;    // Puntos de spawn.
    public GameObject[] enemies;    // Enemigos que spawneara.
    public int waveCount;
    public int wave;    // Oleada actual.
    public int enemyType;   // Tipo de enemigo 0=Buscador 1=Verdugo.
    public bool spawning;   // Spawneando.
    public int enemiesSpawned;  // Cantidad de enemigos spawneados.
    //public WaveManager gameManager;

    [Header("Enemies Stuff")]
    //public Enemy enmy1;
    //public Enemy2 enmy2;
    public int defeatedEnemies;
    public int enemiesCounterAnt;
    public int enemiesCounter;

    public Player plyr;

    void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        waveCount = 4;
        wave = 1;
        spawning = false;
        enemiesSpawned = 0;
        //gameManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        //enmy1 = GameObject.FindGameObjectWithTag("Buscador").GetComponent<Enemy>();
        //enmy2 = GameObject.FindGameObjectWithTag("Verdugo").GetComponent<Enemy2>();
        defeatedEnemies = 0;
    }


    void Update()
    {
        if(spawning == false && enemiesSpawned == plyr.enemigosDerrotados)
        {
            StartCoroutine(SpawnWave(waveCount));
        }

        /*if (enemies[enemyType].GetComponent<Enemy>().dead == true)
        {
            defeatedEnemies++;
        }

        if (enemies[enemyType].GetComponent<Enemy2>().dead == true)
        {
            defeatedEnemies++;
        }*/
    }

    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;
        // Mostrar en texto que ronda esta
        yield return new WaitForSeconds(4f);
        // Desactivar el texto
        for (int i = 0; i < waveC; i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(2f);
        }
        wave += 1;
        //waveCount += 1;
        spawning = false;

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
}

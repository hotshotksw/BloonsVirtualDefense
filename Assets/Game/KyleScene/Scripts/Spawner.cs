using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class BloonGroup
    {
        public Transform enemy;
        public int count;
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public BloonGroup[] enemies;
        // public Transform[] enemies;
        // public int[] count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 2f;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;
    
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }



    void Update ()
    {
        if (state == SpawnState.WAITING)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                WaveCompleted();
            } else
            {
                return;
            }
        }
        
        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log ("ALL WAVES COMPLETE! Looping.");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        // Spawn
        for (int i = 0; i < _wave.enemies.Length; i++)
        {
            for (int j = 0; j < _wave.enemies[i].count; j++)
            {
                SpawnEnemy(_wave.enemies[i].enemy);
                yield return new WaitForSeconds(1f/_wave.rate);
            }
            
        }

        state = SpawnState.WAITING;
        
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, transform.position, transform.rotation);
        Debug.Log ("Spawning Enemy: " + _enemy.name);
    }
}

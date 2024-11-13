using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Update ()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                // Begin a new round
                Debug.Log("Wave Completed");
            } else
            {
                return;
            }
        }
        
        if (countdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            countdown -= Time.deltaTime;
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
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
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

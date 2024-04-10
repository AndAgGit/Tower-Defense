using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public float timeBetweenWaves = 5f;
    public Transform spawnPoint;
    public Wave[] waves;

    private static int wave = 0;
    private static float countdown = 2f;
    void Update()
    {
        if(enemiesAlive > 0)
        {
            countdown = timeBetweenWaves; ;
            return;
        }

        if (countdown <= -1f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, -1f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave curWave = waves[wave];

        for (int i = 0; i < curWave.numToSpawn; i++)
        {
            SpawnEnemy(curWave.enemyPrefab);
            yield return new WaitForSeconds(1f/curWave.spawnRatePerSecond);
        }

        wave++;

        if(wave == waves.Length)
        {
            Debug.Log("Level Complete");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Vector3 randomSpawn = spawnPoint.position + Vector3.forward * Random.Range(-1f, 1f);
        Instantiate(enemy, randomSpawn, Quaternion.identity);
        enemiesAlive++;
    }

    public static int GetWave()
    {
        return wave;
    }

    public static float GetCountdown()
    {
        return countdown;
    }

    public static float GetCountdownCiel()
    {
        return Mathf.Ceil(WaveSpawner.GetCountdown());
    }
}

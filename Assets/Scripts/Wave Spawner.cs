using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float timeBetweenWaves = 10f;
    public float timeBetweenEnemies = 0.25f;
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    private static int wave = 0;
    private static float countdown = 2f;
    void Update()
    {
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, -1f, Mathf.Infinity);
        

        if (countdown <= -1f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
    }

    IEnumerator SpawnWave()
    {
        wave++;

        int numEnemies = 2 * wave;

        Debug.Log("New Wave: " + numEnemies);
        

        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }

        wave++;
    }

    private void SpawnEnemy()
    {
        Vector3 randomSpawn = spawnPoint.position + Vector3.forward * Random.Range(-1f, 1f);
        Instantiate(enemyPrefab, randomSpawn, Quaternion.identity);
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

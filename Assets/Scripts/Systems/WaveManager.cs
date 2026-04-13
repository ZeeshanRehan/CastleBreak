using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemyCount = 4;

    private List<GameObject> aliveEnemies = new List<GameObject>();

    void Start()
    {
        SpawnWave();
    }

    void Update()
    {
        aliveEnemies.RemoveAll(enemy => enemy == null);

        if (aliveEnemies.Count == 0)
        {
            Debug.Log("Wave Cleared");
        }
    }

    void SpawnWave()
    {
        aliveEnemies.Clear();

        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawn = spawnPoints[i % spawnPoints.Length];
            GameObject enemy = Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
            aliveEnemies.Add(enemy);
        }
    }
}
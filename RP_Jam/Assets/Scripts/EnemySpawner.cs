using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float spawnIntervalMin = 2f, spawnIntervalMax = 3f;
    float spawnInterval;
    float timer = 0;


    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            timer = 0;
        }

    }

}

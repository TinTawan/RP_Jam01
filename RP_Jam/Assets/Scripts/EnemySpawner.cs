using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] UI_Manager ui;

    [SerializeField] float spawnIntervalMin = 2f, spawnIntervalMax = 3f;
    float spawnInterval;
    float timer = 0;

    GameObject spawnedEnemy;


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

            spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            //ui.AddEnemyToList(spawnedEnemy.GetComponent<Enemy>());

            timer = 0;
        }

    }


}

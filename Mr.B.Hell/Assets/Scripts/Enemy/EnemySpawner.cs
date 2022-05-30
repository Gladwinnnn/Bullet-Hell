using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay = 0.5f;
    [SerializeField] float maxSpawnDelay = 2f;
    [SerializeField] GameObject[] enemy;
    [SerializeField] Vector2 playArea;
    [SerializeField] int numberOfEnemies;

    float countDown = 60f;
    bool spawnNextWave = false;

    void Update()
    {
        numberOfEnemies = FindObjectsOfType<Enemy>().Length;
        countDown -= Time.deltaTime;
        if (countDown <= 0) spawnNextWave = true;
    }

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (numberOfEnemies <= 20 && !spawnNextWave) SpawnFirstWave();
            else if (numberOfEnemies <= 20 && spawnNextWave) SpawnEnemies();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    void SpawnEnemies()
    {
        float randomYCoordinates = Random.Range(-playArea.x, playArea.x);
        float randomXCoordinates = Random.Range(-playArea.y, playArea.y);
        Vector2 spawnLocation = new Vector2(randomXCoordinates, randomYCoordinates);
        int enemyToSpawn = Random.Range(0,enemy.Length);
        Instantiate(enemy[enemyToSpawn], spawnLocation, Quaternion.identity);
    }

    void SpawnFirstWave()
    {
        float randomYCoordinates = Random.Range(-playArea.x, playArea.x);
        float randomXCoordinates = Random.Range(-playArea.y, playArea.y);
        Vector2 spawnLocation = new Vector2(randomXCoordinates, randomYCoordinates);
        Instantiate(enemy[0], spawnLocation, Quaternion.identity);
    }
}

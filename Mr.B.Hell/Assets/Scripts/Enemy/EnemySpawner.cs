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

    int numberOfEnemies;
    float countDown = 60f;
    bool spawnNextWave = false;

    void Update()
    {
        countDown -= Time.deltaTime;
        Debug.Log(countDown);
    }

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (countDown <= 0) spawnNextWave = true;

            if (numberOfEnemies <= 20 && !spawnNextWave)
            {
                SpawnFirstWave();
                numberOfEnemies++;
            }
            else if (numberOfEnemies <= 20 && spawnNextWave)
            {
                SpawnEnemies();
                numberOfEnemies++;
            }
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

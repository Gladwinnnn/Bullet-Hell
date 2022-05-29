using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay = 0.5f;
    [SerializeField] float maxSpawnDelay = 2f;
    [SerializeField] GameObject[] enemy;
    [SerializeField] float yCoordinatesMin = -4.5f;
    [SerializeField] float yCoordinatesMax = 4.5f;
    [SerializeField] float xCoordinatesMin = -8.3f;
    [SerializeField] float xCoordinatesMax = 8.3f;

    int numberOfEnemies;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (numberOfEnemies <= 20)
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
        float randomYCoordinates = Random.Range(yCoordinatesMin, yCoordinatesMax);
        float randomXCoordinates = Random.Range(xCoordinatesMin, xCoordinatesMax);
        Vector2 spawnLocation = new Vector2(randomXCoordinates, randomYCoordinates);
        int enemyToSpawn = Random.Range(0,enemy.Length);
        Instantiate(enemy[enemyToSpawn], spawnLocation, Quaternion.identity);
    }
}

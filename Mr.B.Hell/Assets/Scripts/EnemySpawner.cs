using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay = 0.5f;
    [SerializeField] float maxSpawnDelay = 2f;
    [SerializeField] GameObject enemy;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemies();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    void SpawnEnemies()
    {
        float yCoordinates = Random.Range(-4.5f, 4.5f);
        float xCoordinates = Random.Range(-8.3f, 8.3f);
        Vector2 spawnLocation = new Vector2(xCoordinates, yCoordinates);
        Instantiate(enemy, spawnLocation, Quaternion.identity);
    }
}

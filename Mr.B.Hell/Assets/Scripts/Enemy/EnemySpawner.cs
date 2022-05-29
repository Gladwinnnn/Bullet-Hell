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
        float randomYCoordinates = Random.Range(-playArea.x, playArea.x);
        float randomXCoordinates = Random.Range(-playArea.y, playArea.y);
        Vector2 spawnLocation = new Vector2(randomXCoordinates, randomYCoordinates);
        int enemyToSpawn = Random.Range(0,enemy.Length);
        Instantiate(enemy[enemyToSpawn], spawnLocation, Quaternion.identity);
    }
}

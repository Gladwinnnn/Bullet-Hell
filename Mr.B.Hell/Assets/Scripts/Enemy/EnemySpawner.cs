using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay = 0.5f;
    [SerializeField] float maxSpawnDelay = 2f;
    [SerializeField] GameObject[] enemy;
    [SerializeField] Vector2 playArea;
    [SerializeField] int numberOfEnemies;
    [SerializeField] int maxNumberOfEnemies = 20;

    float delayForEnemyToSpawn = 2.5f;
    float countDown = 60f;
    float secondCountDown = 120f;
    float finalCountDown = 180f;

    bool spawnSecondWave = false;
    bool spawnThirdWave = false;
    bool spawnLastWave = false;
    int level;

    void Update()
    {
        numberOfEnemies = FindObjectsOfType<Enemy>().Length;
        delayForEnemyToSpawn -= Time.deltaTime;

        if (level == 1 || level == 2)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0) spawnSecondWave = true;
        }
        else if (level == 3)
        {
            countDown -= Time.deltaTime;
            secondCountDown -= Time.deltaTime;
            finalCountDown -= Time.deltaTime;

            if (countDown <= 0) spawnSecondWave = true;
            if (secondCountDown <= 0) spawnThirdWave = true;
            if (finalCountDown <=0) spawnLastWave = true;
        }
    }

    IEnumerator Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        
        if (delayForEnemyToSpawn <= 0)
        {
            if (level == 1) 
            {
                while(spawn)
                {
                    yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                    if (numberOfEnemies <= maxNumberOfEnemies) SpawnEnemies();
                }
            }
            else if (level == 2)
            {
                while(spawn)
                {
                    yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                    if (numberOfEnemies <= maxNumberOfEnemies && !spawnSecondWave) SpawnFirstWave();
                    else if (numberOfEnemies <= maxNumberOfEnemies && spawnSecondWave) SpawnEnemies();
                }
            }
            else if (level == 3)
            {
                while(spawn)
                {
                    yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                    if (numberOfEnemies <= maxNumberOfEnemies && !spawnSecondWave) SpawnFirstWave();
                    else if (numberOfEnemies <= maxNumberOfEnemies && spawnSecondWave) SpawnSecondWave();
                    else if (numberOfEnemies <= maxNumberOfEnemies && spawnThirdWave) SpawnThirdWave();
                    else if (numberOfEnemies <= maxNumberOfEnemies && spawnLastWave) SpawnEnemies();
                }
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

    void SpawnSecondWave()
    {
        float randomYCoordinates = Random.Range(-playArea.x, playArea.x);
        float randomXCoordinates = Random.Range(-playArea.y, playArea.y);
        Vector2 spawnLocation = new Vector2(randomXCoordinates, randomYCoordinates);
        int enemyToSpawn = Random.Range(0,2);
        Instantiate(enemy[enemyToSpawn], spawnLocation, Quaternion.identity);
    }

    void SpawnThirdWave()
    {
        float randomYCoordinates = Random.Range(-playArea.x, playArea.x);
        float randomXCoordinates = Random.Range(-playArea.y, playArea.y);
        Vector2 spawnLocation = new Vector2(randomXCoordinates, randomYCoordinates);
        int enemyToSpawn = Random.Range(0,4);
        Instantiate(enemy[enemyToSpawn], spawnLocation, Quaternion.identity);
    }
}

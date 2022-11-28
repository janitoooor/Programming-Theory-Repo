using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public GameObject[] enemyPrefab;
    private GameManager gameManager;

    private int posX = 6;
    private int maxPosZ = 9;
    private int minPosZ = 5;
    private float posY = 0.2f;

    public int waveNumber = 1;
    public int enemyCount;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        RandomSpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<MoveEnemy>().Length;
        if(enemyCount == 0 && gameManager.gameOver != true)
        {
            waveNumber++;
            RandomSpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }

    }

    private void RandomSpawnEnemyWave(int enemiesToSpawn)
    {
        if (gameManager.gameOver != true)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {

                int prefabIndex = Random.Range(0, enemyPrefab.Length);
                Instantiate(enemyPrefab[prefabIndex], GenerateSpawnPos(), enemyPrefab[prefabIndex].transform.rotation);
                Debug.Log("Wave" + waveNumber);
            }
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        int randomPosZ = Random.Range(minPosZ, maxPosZ);
        Vector3 spawnPos = new Vector3(posX, posY, randomPosZ);
        return spawnPos;
    }

    private void SpawnPowerUp()
    {
        int randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
        if(gameManager.gameOver != true)
        {
            Instantiate(powerUpPrefabs[randomPowerUp], GenerateSpawnPos(), powerUpPrefabs[randomPowerUp].transform.rotation);
        }
    }
    
}

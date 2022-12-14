using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] protected GameObject[] powerUpPrefabs;
    [SerializeField] protected GameObject[] enemyPrefab;

    [SerializeField] protected private int posX { get; private set; } = 7;// ENCAPSULATION
    [SerializeField] protected private int maxPosZ { get; private set; } = 9;// ENCAPSULATION
    [SerializeField] protected private int minPosZ { get; private set; } = 5;// ENCAPSULATION
    [SerializeField] protected private float posY { get; private set; } = 0.2f;// ENCAPSULATION

    [SerializeField] public static int waveNumber = 0;// ENCAPSULATION
    [SerializeField] protected private int enemyCount { get; private set; }// ENCAPSULATION

    protected private void Update()
    {
        StartWaves();// ABSTRACTION
    }
    protected private void StartWaves()// POLYMORPHISM
    {
        enemyCount = FindObjectsOfType<MoveEnemy>().Length;
        if (enemyCount == 0 && MainUI.gameOver != true)
        {
            waveNumber++;
            RandomSpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
    }

    protected private void RandomSpawnEnemyWave(int enemiesToSpawn)
    {
        if (MainUI.gameOver != true)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {

                int prefabIndex = Random.Range(0, enemyPrefab.Length);
                Instantiate(enemyPrefab[prefabIndex], GenerateSpawnPos(), enemyPrefab[prefabIndex].transform.rotation);
                Debug.Log("Wave" + waveNumber);
            }
        }
    }

    protected private Vector3 GenerateSpawnPos()
    {
        int randomPosZ = Random.Range(minPosZ, maxPosZ);
        Vector3 spawnPos = new Vector3(posX, posY, randomPosZ);
        return spawnPos;
    }

    protected private void SpawnPowerUp()// ABSTRACTION
    {
        int randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
        if(MainUI.gameOver != true)
        {
            Instantiate(powerUpPrefabs[randomPowerUp], GenerateSpawnPos(), powerUpPrefabs[randomPowerUp].transform.rotation);
        }
    }
}

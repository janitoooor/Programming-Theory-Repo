using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpawnEnemys spawnEnemys;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemys = GameObject.Find("SpawnManager").GetComponent<SpawnEnemys>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            Debug.Log("Game Over!Wave " + spawnEnemys.waveNumber);
        }
    }
}

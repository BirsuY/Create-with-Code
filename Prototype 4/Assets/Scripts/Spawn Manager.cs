using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 10.0f;
    private int enemyNumber = 1;
    public int enemyCount;

    void Start()
    {
        SpawnEnemyWave(1);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount==0){
            if(enemyNumber < 3){
                SpawnEnemyWave(++enemyNumber);
                SpawnPowerUp();
            }
            
            
        }
    }

    void SpawnEnemyWave(int enemyNumber){
        for(int i = 0; i < enemyNumber; i++){
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUp(){
        Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPos(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX,0,spawnPosY);

        return randomPos;
    }
}

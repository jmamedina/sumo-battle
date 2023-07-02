using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //get the enemy prefab
    public GameObject enemyPrefab;
    //set the spawn range
    private float spawnRange = 10;
    public int enemyCount;
    public int powerupCount;
    public int waveNumber = 1;

    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(3);
        spawnPowerUp();
    }

    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GemerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void spawnPowerUp()
    {
        Instantiate(powerupPrefab, GemerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;

        if(enemyCount == 0) {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            if(powerupCount == 0)
            {
                spawnPowerUp();
            }
        };

    }

    private Vector3 GemerateSpawnPosition()
    {
        //set the spawn pos x
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        //set the spaw pos y
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        //clone the enemyprefab

        //create a new vector3 for the random position
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }


}

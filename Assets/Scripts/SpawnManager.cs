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

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(3);
    }

    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GemerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0) { spawnEnemyWave(1);  };

        if(transform.position.y > -10)
        {
            Destroy(gameObject);
        }
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

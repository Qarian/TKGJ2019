using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public int spawnLimit = 5;
    public float spawnDelay = 2.0f;

    public int currentEnemiesSpawned = 0;


    private void Update()
    {
        CreateEnemy();
    }



    void CreateEnemy()
    {
        if( currentEnemiesSpawned != spawnLimit)
        {
            GameObject enem = Instantiate(enemy, transform.position, Quaternion.identity);

            enem.GetComponent<EnemyBehaviour>().spawner = this;
            currentEnemiesSpawned++;

        }
        

        

    }



}

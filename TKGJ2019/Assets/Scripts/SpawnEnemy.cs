using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public int spawnLimit = 5;
    public float spawnDelay = 10f;
    private float spawnTime = 0;
    public int currentEnemiesSpawned = 0;

    private void Update()
    {
        if (spawnTime <= Time.time)
        {
            CreateEnemy();
            spawnTime = Time.time + spawnDelay;
        }
            
    }

    void CreateEnemy()
    {
        if ( currentEnemiesSpawned < spawnLimit)
        {
            GameObject enem = Instantiate(enemy, transform.position, Quaternion.identity, transform);

            enem.GetComponent<EnemyBehaviour>().spawner = this;
            currentEnemiesSpawned++;
            

           

        }
    }

    void DestroyEnemy()
    {
        currentEnemiesSpawned--;
    }

}

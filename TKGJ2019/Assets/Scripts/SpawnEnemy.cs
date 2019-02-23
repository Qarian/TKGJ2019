﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public int spawnLimit = 5;
    public float spawnDelay = 2.0f;
    private float spawnTime = 0;
    public int currentEnemiesSpawned = 0;

    private void Update()
    {
        if (spawnTime <= Time.time)
        {
            CreateEnemy();
        }
            
    }

    void CreateEnemy()
    {
        Debug.Log(currentEnemiesSpawned + " " + spawnLimit);

        if ( currentEnemiesSpawned <= spawnLimit)
        {
            GameObject enem = Instantiate(enemy, transform.position, Quaternion.identity, transform);

            enem.GetComponent<EnemyBehaviour>().spawner = this;
            currentEnemiesSpawned++;
            

            spawnTime = Time.time + spawnDelay;

        }
    }

    void DestroyEnemy()
    {
        currentEnemiesSpawned--;
    }

}

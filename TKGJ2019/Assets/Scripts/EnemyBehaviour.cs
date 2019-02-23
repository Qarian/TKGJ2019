﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject resorces;

    public int EnemyHP = 10;
    public SpawnEnemy spawner;

    public void DealDamage(int damage)
    {
        EnemyHP -= damage;

        if (EnemyHP <= 0)
            EnemyDestroy();
        
    }

    void EnemyDestroy()
    {
        GameObject money =  Instantiate(resorces, transform.position, Quaternion.identity);

        Destroy(gameObject);
        spawner.currentEnemiesSpawned--;
        
    }

}

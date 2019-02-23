using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public int SpawnLimit = 5;
    public float spawnDelay = 2.0f;


    void CreateEnemy()
    {
        Instantiate(enemy,transform.position, Quaternion.identity);
        
    }

}

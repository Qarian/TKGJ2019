using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public int spawnLimit = 5;
    public float spawnDelay = 2.0f;
    private float spawnTime = 0;
    public int currentEnemiesSpawned = 0;

	public List<Transform> path;

    private void Update()
    {
        if (spawnTime <= Time.time)
        {
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        if ( currentEnemiesSpawned <= spawnLimit)
        {
            GameObject enem = Instantiate(enemy, transform.position, Quaternion.identity, transform);

            enem.GetComponent<EnemyBehaviour>().spawner = this;
			EnemyMovement enemyMovement = enem.GetComponent<EnemyMovement>();
			enemyMovement.path = path;
			enemyMovement.target = path[0];
            currentEnemiesSpawned++;

            spawnTime = Time.time + spawnDelay;
        }
    }

    void DestroyEnemy()
    {
        currentEnemiesSpawned--;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.GetComponent<Zone>() != null)
        {

            // collision.GetComponent<SpawnEnemy>().enabled = false;
            Destroy(transform);
        }
    }

}

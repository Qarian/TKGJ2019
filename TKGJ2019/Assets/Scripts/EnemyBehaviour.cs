using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int EnemyHP = 10;
    public SpawnEnemy spawner;

    public void DealDamage(int damage)
    {
        EnemyHP -= damage;
		GetComponent<EnemyMovement>().AttackPlayer();

        if (EnemyHP <= 0)
            EnemyDestroy();
    }

    void EnemyDestroy()
    {
        Destroy(gameObject);
        spawner.currentEnemiesSpawned--;
    }

}

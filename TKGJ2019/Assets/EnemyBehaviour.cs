using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int EnemyHP = 10;

    public void DealDamage(int damage)
    {
        EnemyHP -= damage;

        if (EnemyHP <= 0)
            EnemyDestroy();
        
    }

    void EnemyDestroy()
    {
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBehaviour>() != null) return;

        Debug.Log("BULLET TRIGERRED");
        var col = collision.gameObject.GetComponent<PlayerHP>();
        
        if (col != null)
        {
            col.DealDamageToPlayer(damage);
        }
        
       // Destroy(gameObject);
               
        
    }


}

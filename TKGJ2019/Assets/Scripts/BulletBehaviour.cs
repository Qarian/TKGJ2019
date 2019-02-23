using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public int damage =4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null) return;

        Debug.Log("BULLET TRIGERRED");
        var col = collision.gameObject.GetComponent<EnemyBehaviour>();
        
        if (col != null)
        {
            col.DealDamage(damage);
        }
        
        Destroy(gameObject);
               
        
    }


}

using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public int damage =4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.GetComponent<PlayerMovement>() != null) return;

        var col = collision.gameObject.GetComponent<EnemyBehaviour>();
        
        if (col != null)
        {
            col.DealDamage(damage);
        }
        
        Destroy(gameObject);
    }
}

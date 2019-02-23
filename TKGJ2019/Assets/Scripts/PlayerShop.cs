using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShop : MonoBehaviour
{
    public int money = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.tag == "Money")
        {
            money++;
            Destroy(collision.gameObject);

            Debug.Log(money);
        }
    }
}

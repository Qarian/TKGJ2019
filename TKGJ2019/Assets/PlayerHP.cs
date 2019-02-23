using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject particle;

    public int playerHP = 4;

    public void DealDamageToPlayer(int damage)
    {
        playerHP -= damage;

        Debug.Log(playerHP);
     

       
        

        
        if (playerHP <= 0)
        {
            PlayerDestroy();
        }

        particle = Instantiate(particle, transform.position, Quaternion.identity, transform);
    }

    void PlayerDestroy()
    {
        Destroy(gameObject);
        
    }
}

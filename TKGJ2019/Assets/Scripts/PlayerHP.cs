using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int playerHP = 4;

    public void DealDamageToPlayer(int damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
            PlayerDestroy();

    }

    void PlayerDestroy()
    {
        Destroy(gameObject);
        
    }
}

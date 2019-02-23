using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;

    

    public float bulletSpeed = 2;
    public float bulletCooldown =3;
    public float bulletDestroy = 4;
    
    private float bulletTime=0;

    private void Update()
    {
        

        if (bulletTime <= Time.time)
        {
            Shooting(PlayerMovement.playerPos.rotation);

        }
    }
    void Shooting( Quaternion direction)
    {
        GameObject shot = Instantiate(bullet, transform.position,direction);

            
        shot.GetComponent<Rigidbody2D>().AddForce(shot.transform.up * bulletSpeed, ForceMode2D.Impulse);


        bulletTime = Time.time + bulletCooldown;

            Destroy(shot, bulletDestroy);
    }


   

    
}
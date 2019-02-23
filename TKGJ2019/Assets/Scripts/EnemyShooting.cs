using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;

    

    public float bulletSpeed = 2;
    public float bulletCooldown =3;
    public float bulletDestroy = 3;
    
    private float bulletTime=0;

    private void Update()
    {
        Debug.Log(PlayerMovement.playerPos.position - transform.position);

        if (bulletTime <= Time.time)
        {
            Shooting(PlayerMovement.playerPos.position-transform.position);

        }
    }
    void Shooting( Vector3 direction)
    {
        GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);

      


        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shot.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        shot.GetComponent<Rigidbody2D>().AddForce(shot.transform.up * bulletSpeed, ForceMode2D.Impulse);


        bulletTime = Time.time + bulletCooldown;

            Destroy(shot, bulletDestroy);
    }


   

    
}
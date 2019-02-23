using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;

    private int direction = 0;

    public float bulletSpeed;
    public float bulletCooldown;
    public float bulletDestroy;
    
    private float bulletTime;

	Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow)) direction = 7;


            else if (Input.GetKey(KeyCode.DownArrow)) direction = 5;

            else direction = 6;
        }


        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow)) direction = 1;


            else if (Input.GetKey(KeyCode.DownArrow)) direction = 3;

            else direction = 2;
        }

        else if (Input.GetKey(KeyCode.UpArrow)) direction = 8;
        else if (Input.GetKey(KeyCode.DownArrow)) direction = 4;

        else direction = 0;

        if (direction != 0 && bulletTime <= Time.time)
        {
            Shooting(direction);
			animator.SetTrigger("Fire");
        }
    }
    void Shooting(int direction)
    {
        GameObject shot = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, direction * 45)));

            
        shot.GetComponent<Rigidbody2D>().AddForce(shot.transform.up * bulletSpeed, ForceMode2D.Impulse);


        bulletTime = Time.time + bulletCooldown;

            Destroy(shot, bulletDestroy);
    }


   

    
}
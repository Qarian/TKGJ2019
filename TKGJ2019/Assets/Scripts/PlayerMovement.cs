﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI moneyUI;
    public static Transform playerPos;
    Zone zone;
    public float Speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;

	float horizontal;
	float vertical;
	Animator animator;

    public int neededMoney = 10;
    public int resources = 0;

    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerPos = transform;

        moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveInput = moveInput.normalized;

		horizontal = moveInput.x;
		vertical = moveInput.y;
		animator.SetFloat("Horizontal", horizontal);
		animator.SetFloat("Vertical", vertical);
        
        moveVelocity = moveInput * Speed;

        if (Input.GetKey(KeyCode.Space))
        {
          //  transform.localScale = new Vector3(2, 2, 2);
          //  Invoke("DecreaseSize", 1);
         
            if(zone != null && transform.GetComponent<PlayerShop>().money <= neededMoney )
            {
                if(Camera.main.orthographicSize <= 10.1f )
                    Camera.main.orthographicSize += 0.1f;


                transform.GetComponent<PlayerShop>().money -= neededMoney;

                Debug.Log(transform.GetComponent<PlayerShop>().money);
                moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();

                zone.IncreaseScale();
            }
        }
        else if (Camera.main.orthographicSize >= 7.55f)
            Camera.main.orthographicSize -= 0.01f;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.tag == "Flower")
			zone = other.transform.GetComponent<Zone>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
		if(other.transform.tag == "Flower")
        zone = null;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void DecreaseSize()
    {
        transform.localScale = Vector3.one;
    }


}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Zone zone;
    public float Speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput.normalized * Speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
          //  transform.localScale = new Vector3(2, 2, 2);
          //  Invoke("DecreaseSize", 1);
            if(zone != null)
            {
                zone.IncreaseScale();
            }
        }

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
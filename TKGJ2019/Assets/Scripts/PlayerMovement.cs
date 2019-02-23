using System.Collections;
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

    public int neededMoney = 10;

    public int resources = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = transform;

        moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        
        moveVelocity = moveInput.normalized * Speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
          //  transform.localScale = new Vector3(2, 2, 2);
          //  Invoke("DecreaseSize", 1);
         
            if(zone != null && transform.GetComponent<PlayerShop>().money >= neededMoney )
            {

                transform.GetComponent<PlayerShop>().money -= neededMoney;

                Debug.Log(transform.GetComponent<PlayerShop>().money);
                moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();

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

using UnityEngine;
using TMPro;
using FMODUnity;

public class PlayerMovement : MonoBehaviour
{
    public int playerLevel = 0;
    public static PlayerMovement movee;
    public TextMeshProUGUI moneyUI;
    public static Transform playerPos;
    Zone zone;
    public float Speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;

	float horizontal;
	float vertical;
	Animator animator;
	StudioEventEmitter emitter;

	float howMuchGreenProgress;
	bool isInZone;

    public int neededMoney = 10;
    public int resources = 0;

    private int checkedZones = 0;
    public GameObject endgame;

    // Start is called before the first frame update
    void Start()
    {
        movee = this;
		animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerPos = transform;

        moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();
		emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)) CameraZoom();
        if (Input.GetKey(KeyCode.X)) CameraOut();

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
         
            if(zone != null && transform.GetComponent<PlayerShop>().money >= 1 )
            {
                if (zone.isMaxScale == true)
                {
                    Destroy(zone);

                    CameraZoom();



                        checkedZones++;
                    if (checkedZones >= 4)
                    {
                        endgame.SetActive(true);
                        CameraZoom();
                    }

                    Debug.Log(checkedZones);
                    return;
                }

                if(Camera.main.orthographicSize <= 10.1f )
                    Camera.main.orthographicSize += 0.1f;


                transform.GetComponent<PlayerShop>().money -= 1;
                
                moneyUI.text = transform.GetComponent<PlayerShop>().money.ToString();

                zone.IncreaseScale();
            }
        }
		else if (Camera.main.orthographicSize >= 4.55f)
            Camera.main.orthographicSize -= 0.01f;
		if (isInZone)
		{
			isInZone = false;
			howMuchGreenProgress = Mathf.Clamp01(howMuchGreenProgress + (0.5f * Time.deltaTime));
		}
		else
			howMuchGreenProgress = Mathf.Clamp01(howMuchGreenProgress - (0.5f * Time.deltaTime));
		emitter.SetParameter("zone", howMuchGreenProgress);
        

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

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag == "Zone")
			isInZone = true;
	}

	private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void DecreaseSize()
    {
        transform.localScale = Vector3.one;
    }

    public void LevelUp()
    {
        playerLevel++;
        animator.SetInteger("level", playerLevel);
    }

    public void CameraZoom()
    {
        if (Camera.main.orthographicSize >= 1f) Camera.main.orthographicSize -= 0.5f;
    }

    public void CameraOut()
    {
        if (Camera.main.orthographicSize <= 25f) Camera.main.orthographicSize += 0.5f;
    }
}

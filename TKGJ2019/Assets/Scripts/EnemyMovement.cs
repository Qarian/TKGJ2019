using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 5;
	public float horizontal;
	public float vertical;
	public bool firing = false;

	Animator animator;
	Rigidbody2D rb;
	Vector3 previousPosition;

	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		animator.SetFloat("Horizontal", horizontal);
		animator.SetFloat("Vertical", vertical);
		animator.SetBool("Firing", firing);
	}

	private void FixedUpdate()
	{
		Vector3 distance = (PlayerMovement.playerPos.position - transform.position).normalized * speed * Time.deltaTime;
		rb.MovePosition(transform.position + distance);
	}
}

using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 5f;
	public float seeDistance = 10f;
	public float shootingDistance = 10f;
	public float distanceToNextpointInPath = 0.03f;
	float horizontal;
	float vertical;
	bool firing = false;

	[HideInInspector]
	public List<Transform> path;
	int currentPathPoint = 0;

	bool seenPlayer = false;
	[HideInInspector]
	public Transform target;

	Animator animator;
	Rigidbody2D rb;
	Vector3 previousPosition;
	EnemyShooting shooting;

	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		shooting = GetComponent<EnemyShooting>();
		shooting.enabled = false;
	}

	void Update()
	{
		if (!seenPlayer)
		{
			//Try to see player
			RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, PlayerMovement.playerPos.position - transform.position, seeDistance, 1 << 10);
			if(raycastHit.collider != null && raycastHit.collider.tag == "Player")
			{
				FocusOnPlayer();
			}
			//check if near point
			else
			{
				if((transform.position - target.position).magnitude < distanceToNextpointInPath)
				{
					currentPathPoint++;
					if(currentPathPoint >= path.Capacity)
						currentPathPoint=0;
					target = path[currentPathPoint];
				}
			}
		}
		else
		{
			RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, PlayerMovement.playerPos.position - transform.position, shootingDistance, 1 << 10);
			if(raycastHit.collider != null && raycastHit.collider.tag == "Player")
			{
				firing = true;
				shooting.enabled = true;
			}
			else
			{
				firing = false;
				shooting.enabled = false;
			}
		}

		animator.SetFloat("Horizontal", horizontal);
		animator.SetFloat("Vertical", vertical);
		animator.SetBool("Firing", firing);
	}

	private void FixedUpdate()
	{
		Vector3 distanceNormalized = (target.position - transform.position).normalized;
		horizontal = distanceNormalized.x;
		vertical = distanceNormalized.y;
		if (!firing)
		{
			Vector3 distance = distanceNormalized * speed * Time.deltaTime;
			rb.MovePosition(transform.position + distance);
		}
	}

	public void FocusOnPlayer()
	{
		target = PlayerMovement.playerPos;
		seenPlayer = true;
	}
}

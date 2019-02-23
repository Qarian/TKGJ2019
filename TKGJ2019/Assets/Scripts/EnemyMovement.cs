using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 5;
	public float seeDistance = 10;
	public float distanceToNextpointInPath = 0.03f;
	float horizontal;
	float vertical;
	public bool firing = false;

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
			RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, PlayerMovement.playerPos.position - transform.position, seeDistance);
			if(raycastHit.collider != null && raycastHit.collider.tag == "Player")
			{
				AttackPlayer();
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

		animator.SetFloat("Horizontal", horizontal);
		animator.SetFloat("Vertical", vertical);
		animator.SetBool("Firing", firing);
	}

	private void FixedUpdate()
	{
		Vector3 distanceNormalized = (target.position - transform.position).normalized;
		horizontal = distanceNormalized.x;
		vertical = distanceNormalized.y;
		Vector3 distance = distanceNormalized * speed * Time.deltaTime;
		rb.MovePosition(transform.position + distance);
	}

	public void AttackPlayer()
	{
		target = PlayerMovement.playerPos;
		seenPlayer = true;
		shooting.enabled = true;
	}
}

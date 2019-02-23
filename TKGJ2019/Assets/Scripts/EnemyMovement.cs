using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float horizontal;
	public float vertical;
	public bool firing = false;

	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		animator.SetFloat("Horizontal", horizontal);
		animator.SetFloat("Vertical", vertical);
		animator.SetBool("Firing", firing);
	}
}

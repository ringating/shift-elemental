using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public Transform rightMoveLimit;
	public Transform leftMoveLimit;

	public float horizontalVelocity = 1f;

	public bool startMovingRight = false;

	public float rightLimit;
	public float leftLimit;

	private Rigidbody2D rb;

	// Use this for initialization
	private void Start()
	{
		if (rightMoveLimit && leftMoveLimit)
		{
			rightLimit = rightMoveLimit.position.x;
			leftLimit = leftMoveLimit.position.x;

			Destroy(rightMoveLimit.gameObject);
			Destroy(leftMoveLimit.gameObject);
		}

		rb = GetComponent<Rigidbody2D>();

		if (startMovingRight)
		{
			rb.velocity = new Vector2(horizontalVelocity, 0);
		}
		else
		{
			rb.velocity = new Vector2(-horizontalVelocity, 0);
		}
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if (rb.position.x > rightLimit)
		{
			rb.velocity = new Vector2(-horizontalVelocity, 0);
		}
		else if (rb.position.x < leftLimit)
		{
			rb.velocity = new Vector2(horizontalVelocity, 0);
		}
	}
}

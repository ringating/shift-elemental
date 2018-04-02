using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
	public Transform target;
	private Vector2 targetV2;

	public float speed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (target != null)
		{
			targetV2.x = target.position.x;
			targetV2.y = target.position.y;
			rb.velocity = (targetV2 - rb.position).normalized * speed;
		}
	}

	public void SetTarget (Transform t)
	{
		target = t;
	}
}

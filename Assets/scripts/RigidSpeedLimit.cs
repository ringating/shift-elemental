using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidSpeedLimit : MonoBehaviour
{
	public float maxRigidbodySpeed;

	private Rigidbody2D rigid;

	void Start ()
	{
		rigid = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
	{
		if (rigid.velocity.magnitude > maxRigidbodySpeed)
		{
			rigid.velocity = rigid.velocity.normalized * maxRigidbodySpeed;
		}
	}
}

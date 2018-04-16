using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineRotateToFace : MonoBehaviour
{
	public VineGrapple almostTarget;
	private Transform target;

	void Start ()
	{
		target = almostTarget.cs.transform;
	}
	
	void Update ()
	{
		transform.rotation = Quaternion.Euler(0,0,Vector2.SignedAngle(Vector2.right, new Vector2(transform.position.x - target.position.x, transform.position.y - target.position.y)));
	}
}

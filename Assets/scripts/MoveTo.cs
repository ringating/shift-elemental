using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
	public Vector2 targetPosition = Vector2.zero;
	public Transform optionalTargetTransform = null;

	void Start ()
	{
		if (optionalTargetTransform != null)
		{
			targetPosition = new Vector2(optionalTargetTransform.position.x, optionalTargetTransform.position.y);
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		col.transform.position = targetPosition;
	}
}

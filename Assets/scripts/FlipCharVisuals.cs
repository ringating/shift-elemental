using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharVisuals : MonoBehaviour
{
	public CharState player;

	private Vector3 rightVec;
	private Vector3 leftVec;

	void Start ()
	{
		rightVec = transform.localScale;
		leftVec = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void Update ()
	{
		if (player.facingRight)
		{
			transform.localScale = rightVec;
		}
		else
		{
			transform.localScale = leftVec;
		}
	}
}

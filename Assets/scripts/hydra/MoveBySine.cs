using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBySine : MonoBehaviour
{
	// this script locks the transform's local position, so it needs to have a moveable parent if you want to move it elsewhere

	public float xRadius;
	public float yRadius;
	public float xSpeedScalar;
	public float ySpeedScalar;
	public bool moveInX;
	public bool moveInY;

	private float x = 0;
	private float y = 0;
	
	private void Update()
	{
		if (moveInX)
		{
			x = Mathf.Sin(Time.time * xSpeedScalar) * xRadius;
		}
		else
		{
			x = 0;
		}

		if (moveInX)
		{
			y = Mathf.Sin(Time.time * ySpeedScalar) * yRadius;
		}
		else
		{
			y = 0;
		}

		transform.localPosition = new Vector3(x,y,transform.localPosition.z);
	}
}

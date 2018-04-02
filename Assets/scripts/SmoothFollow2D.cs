using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour
{
	public GameObject target;
	public float targetLerpVal;
	public bool useLateUpdate = false;
	public bool useApproximation = false;
	public Vector3 offset = Vector3.zero;

	// Update is called once per frame
	void Update()
	{
		if (!useLateUpdate)
		{
			if (useApproximation)
			{
				DoApproximateThing();
			}
			else
			{
				DoThing();
			}
		}
	}

	void LateUpdate()
	{
		if (useLateUpdate)
		{
			if (useApproximation)
			{
				DoApproximateThing();
			}
			else
			{
				DoThing();
			}
		}
	}

	private void DoThing()
	{
		transform.position = new Vector3(
			Mathf.Lerp(transform.position.x, target.transform.position.x, 1 - Mathf.Pow((1 - targetLerpVal), Time.deltaTime)),
			Mathf.Lerp(transform.position.y, target.transform.position.y, 1 - Mathf.Pow((1 - targetLerpVal), Time.deltaTime)),
			transform.position.z
		);
	}

	private void DoApproximateThing()
	{
		transform.position = new Vector3(
			Mathf.Lerp(transform.position.x, target.transform.position.x, targetLerpVal * Time.deltaTime),
			Mathf.Lerp(transform.position.y, target.transform.position.y, targetLerpVal * Time.deltaTime),
			transform.position.z
		);
	}
}

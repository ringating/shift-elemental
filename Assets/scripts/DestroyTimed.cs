using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimed : MonoBehaviour
{
	public float timeUntilDestroy;
	
	// Update is called once per frame
	void Update ()
	{
		timeUntilDestroy -= Time.deltaTime;

		if (timeUntilDestroy <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}

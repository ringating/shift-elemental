using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThingOnDestroy : MonoBehaviour
{
	public GameObject thing;

	private bool isQuitting;

	void OnApplicationQuit()
	{
		isQuitting = true;
	}

	private void OnDestroy()
	{
		if (!isQuitting)
		{
			Instantiate(thing, transform.position, transform.rotation);
		}
	}
}

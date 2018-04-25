using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThingOnDestroy : MonoBehaviour
{
	public GameObject thing;

	private void OnDestroy()
	{
		Instantiate(thing, transform.position, transform.rotation);
	}
}

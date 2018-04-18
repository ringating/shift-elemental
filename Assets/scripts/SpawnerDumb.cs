using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDumb : MonoBehaviour
{
	public GameObject thingToSpawn;
	public float spawnInterval;

	private float timer = 0f;
	
	void Update ()
	{
		if (timer <= 0)
		{
			// create an instance of the thing, reset timer
			Instantiate(thingToSpawn, transform.position, Quaternion.identity);
			timer = spawnInterval;
		}
		else
		{
			timer -= Time.deltaTime;
		}
	}
}

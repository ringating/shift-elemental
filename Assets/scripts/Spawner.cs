// this script will only work if its associated transform has a child
// this script will spawn a copy of the child object after a specified amount of time has passed since the previous copy was destroyed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	private GameObject thingToSpawn;
	private GameObject activeObject;

	private Transform child;

	public float respawnTime;
	private float timer = 0f;

	private void Start()
	{
		child = transform.GetChild(0);
		thingToSpawn = child.gameObject;
		child.gameObject.SetActive(false);
	}

	void Update ()
	{
		if (activeObject == null)
		{
			if (timer > 0)
			{
				timer -= Time.deltaTime;
			}
			else
			{
				activeObject = Instantiate(thingToSpawn, transform.position, Quaternion.identity);
				activeObject.SetActive(true);
				timer = respawnTime;
			}
		}	
	}
}

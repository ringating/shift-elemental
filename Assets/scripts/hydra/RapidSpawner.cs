using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidSpawner : MonoBehaviour
{

	public GameObject toSpawn;
	public Transform spawnPoint;
	public int count;
	public float interval;
	public float timer; // used as the timer, but setting it to something other than 0 allows for an arbitrary initial delay

	private HomingProjectile temp;
	public Transform player;

	public float speed;
	public float damage;
	public float lifetime;
	
	void Update ()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			timer = interval;
			count--;
			temp = Instantiate(toSpawn, spawnPoint.position, spawnPoint.rotation).GetComponent<HomingProjectile>();
			if (temp)
			{
				temp.target = player;
				temp.speed = speed;
				temp.GetComponent<EnemyAttack>().damage = damage;
				temp.GetComponent<DestroyTimed>().timeUntilDestroy = lifetime;
			}
		}

		if (count <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHeadAni : MonoBehaviour
{

	public float cooldown;
	private float timer;

	private bool inRange = true;

	public Animator ani;

	public Transform player;
	public float activeRange;

	public GameObject rapidSpawnerPrefab;

	public GameObject iceAttack;
	public GameObject grassAttack;

	private RapidSpawner temp;

	public Transform projectileSpawnPoint;

	void Start ()
	{
		timer = cooldown;
	}
	
	void Update ()
	{
		ani.SetInteger("state", 0);

		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			if (inRange)
			{
				Debug.Log("in range");
				// do a thing
				switch (Random.Range((int)0, (int)5))
				{
					case 0:
						Debug.Log(name + ", idle");
						break;

					case 1:
						Debug.Log(name + ", wiggle");
						ani.SetInteger("state",1);
						break;

					case 2:
						Debug.Log(name + ", lean forward");
						ani.SetInteger("state", 2);
						Attack(iceAttack, 3, 0.2f, 0.5f, 6, 10, 2);
						break;

					case 3:
						Debug.Log(name + ", lean back");
						ani.SetInteger("state", 3);
						break;

					case 4:
						Debug.Log(name + ", roar");
						ani.SetInteger("state", 4);
						break;

					default:
						break;
				}
			}

			timer = cooldown;
		}
	}

	private void Attack(GameObject projectile, int count, float interval, float delay, float speed, float damage, float lifetime)
	{
		temp = Instantiate(rapidSpawnerPrefab, transform.position, transform.rotation).GetComponent<RapidSpawner>();
		temp.player = player;
		temp.spawnPoint = projectileSpawnPoint;
		temp.toSpawn = projectile;
		temp.count = count;
		temp.interval = interval;
		temp.timer = delay;
		temp.speed = speed;
		temp.damage = damage;
		temp.lifetime = lifetime;
	}
}

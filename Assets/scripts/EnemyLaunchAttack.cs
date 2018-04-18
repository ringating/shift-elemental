using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaunchAttack : MonoBehaviour
{
	public float AttackCooldownTime;
	public CircleCollider2D trigger;
	public GameObject attack;
	public float attackSpeed = 1;
	public float attackDamage = 1;

	private Transform player;
	private float worldSpaceRadius;
	private RaycastHit2D rh;
	private float timer = 0;

	public AudioSource attackSound;

	// Use this for initialization
	void Start ()
	{
		worldSpaceRadius = trigger.radius * trigger.transform.lossyScale.x;
		trigger.enabled = false;

		timer = AttackCooldownTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			if (PlayerInRange())
			{
				//launch attack, reset timer
				LaunchAttack();
				timer = AttackCooldownTime;
			}
		}
	}

	private bool PlayerInRange()
	{
		rh = Physics2D.CircleCast
		(
			new Vector2(transform.position.x, transform.position.y),
			worldSpaceRadius,
			Vector2.zero,
			0,
			1 << 8 // only checking the "Player1" layer
		);

		if (rh)
		{
			if (rh.collider.gameObject.tag == "Player")
			{
				player = rh.collider.transform;
				return true;
			}
		}
		
		return false;
	}

	private void LaunchAttack()
	{
		attackSound.Play();

		GameObject gObj = Instantiate(attack, transform.position, Quaternion.identity);

		HomingProjectile hProj = gObj.GetComponent<HomingProjectile>();
		if (hProj)
		{
			hProj.target = player;
			hProj.speed = attackSpeed;
		}

		EnemyAttack eAttack = gObj.GetComponent<EnemyAttack>();
		if (eAttack)
		{
			eAttack.damage = attackDamage;
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpear : MonoBehaviour
{

	public float stickingOffset;
	public float speed;
	public BoxCollider2D togglePlat;
	public bool goRight;
	private bool flying = true;
	private Rigidbody2D rigid;

	private RaycastHit2D terrainHit;
	private RaycastHit2D enemyHit;

	// Use this for initialization
	void Start ()
	{
		rigid = GetComponent<Rigidbody2D>();
		if (goRight)
		{
			speed = Mathf.Abs(speed);
			stickingOffset = Mathf.Abs(stickingOffset);
		}
		else
		{
			speed = -Mathf.Abs(speed);
			stickingOffset = -Mathf.Abs(stickingOffset);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flying)
		{
			// move it
			transform.position += new Vector3(speed*Time.deltaTime,0,0);

			// get collisions
			enemyHit = Physics2D.Linecast(transform.position + new Vector3(stickingOffset,0,0), transform.position, 1 << 10);
			terrainHit = Physics2D.Linecast(transform.position + new Vector3(stickingOffset, 0, 0), transform.position, ~((1 << 10) | (1 << 9) | (1 << 8) | (1 << 11)) );

			// check if collided.  ignore player collision, call Damage() if colliding with an enemy, StopFlying() if anything else
			if (enemyHit)
			{
				// colliding with enemy
				//Debug.Log("enemy hit");
				Damage(enemyHit.collider.gameObject);
			}
			else if (terrainHit)
			{
				// colliding with anything but player or enemy
				//Debug.Log("terrain hit, " + terrainHit.collider.gameObject.name);
				StopFlying();
			}
		}
	}

	void LateUpdate()
	{
		if (flying)
		{
			togglePlat.enabled = false;
		}
	}

	/* going with a rigidbody-less implementation instead
	private void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("Ice Spear's OnCollisionEnter2D() called");

		if (flying)
		{
			if (col.gameObject.tag == "Enemy")
			{
				Damage(col.gameObject);
			}
			else if (col.gameObject.tag == "Player")
			{
				// do nothing
			}
			else
			{
				StopFlying();
			}
		}
	}*/

	void Damage(GameObject enemy)
	{
		// do whatever happens when an enemy is hit by an icicle
		Destroy(enemy);
		Destroy(gameObject);
	}

	void StopFlying()
	{
		Destroy(rigid);
		flying = false;
	}
}

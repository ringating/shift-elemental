using System.Collections;
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

	public float lifespan = 3f; // how long (once not flying) until it's destroyed (might eventually remove this for a "destroy when the player jumps off" idea instead)

	private bool firstCheck = true;
	private float distanceAdjusted = 0;
	private float maxDistanceAdjust = 1;
	private float adjustStepSize = .1f;


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
	
	void Update ()
	{
		if (flying)
		{
			// offset if it spawns inside terrain
			if (firstCheck)
			{
				while (distanceAdjusted < maxDistanceAdjust && Physics2D.Linecast(transform.position + new Vector3(stickingOffset, 0, 0), transform.position, ~((1 << 10) | (1 << 9) | (1 << 8) | (1 << 11) | (1 << 12) | (1 << 13) | (1 << 14) | (1 << 15) | (1 << 16))))
				{
					if (goRight)
					{
						transform.position -= new Vector3(adjustStepSize, 0, 0);
					}
					else
					{
						transform.position += new Vector3(adjustStepSize, 0, 0);
					}
					distanceAdjusted += adjustStepSize;
				}
			}
			
			// move it
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

			// get collisions
			enemyHit = Physics2D.Linecast(transform.position + new Vector3(stickingOffset, 0, 0), transform.position, 1 << 10);
			terrainHit = Physics2D.Linecast(transform.position + new Vector3(stickingOffset, 0, 0), transform.position, ~((1 << 10) | (1 << 9) | (1 << 8) | (1 << 11) | (1 << 12) | (1 << 13) | (1 << 14) | (1 << 15) | (1 << 16)) );

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
		else
		{
			// not flying, do the timer to destroy
			if (lifespan > 0)
			{
				lifespan -= Time.deltaTime;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}

		firstCheck = false;
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

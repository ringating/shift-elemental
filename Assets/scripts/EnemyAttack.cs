using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

	public float damage = 1;
	public int type = 999;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		// when it enters the absorb trigger, do stuff
		if (collider.gameObject.tag == "AbsorbTrigger")
		{
			collider.gameObject.GetComponent<AbsorbTrigger>().SetState(type);
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// when it hits the player, deal damage
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<CharState>().Damaged(damage);
			//Debug.Log("attack '" + name + "' collided with the player");
		}

		Destroy(this.gameObject);
	}
}

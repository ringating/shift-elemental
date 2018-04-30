using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnPlayerOverlap : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		CharState temp = collision.GetComponent<CharState>();

		if (collision.gameObject.tag == "Player" && temp)
		{
			temp.Die();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIcedEnemies : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "IcedEnemy")
		{
			Destroy(collision.gameObject);
		}
	}
}

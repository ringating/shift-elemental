using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroyByTag : MonoBehaviour
{
	public string targetTag;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == targetTag)
		{
			Destroy(col.gameObject);
		}
	}
}

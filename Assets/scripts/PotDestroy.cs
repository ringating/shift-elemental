using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDestroy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		Destroy(this.gameObject);
	}
}

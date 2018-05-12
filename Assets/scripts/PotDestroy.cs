using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDestroy : MonoBehaviour
{
	public PotHealth ph;

	private void OnTriggerEnter2D(Collider2D col)
	{
		ph.GiveCharge();
		Destroy(this.gameObject);
	}
}

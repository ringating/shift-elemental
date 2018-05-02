using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public Transform respawnPoint;

	private void OnTriggerEnter2D(Collider2D col)
	{
		CheckpointHandler temp = col.GetComponent<CheckpointHandler>();

		if (temp)
		{
			temp.SetRespawnPoint(respawnPoint.position);
		}
	}
}

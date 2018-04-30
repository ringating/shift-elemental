using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
	private Vector3 respawnPoint;

	private void Start ()
	{
		respawnPoint = transform.position;
	}

	public void SetRespawnPoint( Vector3 point )
	{
		respawnPoint = point;
	}

	public void Respawn ()
	{
		transform.position = respawnPoint;
	}
}

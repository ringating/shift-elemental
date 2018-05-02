using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
	public Vector3 respawnPoint;
	public Transform player;

	private void Start ()
	{
		respawnPoint = player.position;
	}

	public void SetRespawnPoint( Vector3 point )
	{
		respawnPoint = point;
	}

	public void Respawn ()
	{
		player.position = respawnPoint;
	}
}

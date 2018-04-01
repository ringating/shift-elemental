using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbTrigger : MonoBehaviour
{
	public CharState playerState;
	private CircleCollider2D trigger;

	private float activeDuration = 1f;
	private float cooldownDuration = 0.2f;

	private float activeTimer = 0f;
	private float cooldownTimer = 0f;

	private bool inputDown = false;
	private bool inputReleased = false;
	private bool absorbAvailable = true;

	// Use this for initialization
	private void Start ()
	{
		trigger = GetComponent<CircleCollider2D>();
		//trigger.enabled = false;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		
	}

	public void Activate()
	{
		inputDown = true;
	}

	public void SetState (int state)
	{
		playerState.state = state;
		playerState.charge = playerState.maxCharge;
	}

	private void EnableAbsorb()
	{
		trigger.enabled = true;
		activeTimer = activeDuration;
	}

	private void DisableAbsorb()
	{
		trigger.enabled = false;
	}
}

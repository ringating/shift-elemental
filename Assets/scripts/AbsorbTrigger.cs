using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbTrigger : MonoBehaviour
{
	public CharState playerState;
	private CircleCollider2D trigger;

	private float activeDuration = 0.5f;
	private float cooldownDuration = 0.2f;

	private float activeTimer = 0f;
	private float cooldownTimer = 0f;

	private bool inputDown = false;
	private bool inputReleased = false;
	private bool absorbAvailable = false;

	public SpriteRenderer visuals;

	// Use this for initialization
	private void Start ()
	{
		trigger = GetComponent<CircleCollider2D>();
		//trigger.enabled = false;

		DisableAbsorb();
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if (inputDown)
		{
			if (absorbAvailable && inputReleased)
			{
				EnableAbsorb();
				inputReleased = false;
				absorbAvailable = false;
			}
		}
		else
		{
			inputReleased = true;
		}

		if (!absorbAvailable)
		{
			UpdateTimer();
		} 
	}

	public void SetInput(bool input)
	{
		inputDown = input;
	}

	public void SetState (int state)
	{
		playerState.state = state;
		playerState.charge = playerState.maxCharge;
	}

	private void EnableAbsorb()
	{
		//Debug.Log("EnableAbsorb()");
		trigger.enabled = true;
		visuals.enabled = true;

		playerState.ctrl.Stop();
	}

	private void DisableAbsorb()
	{
		//Debug.Log("DisableAbsorb()");
		trigger.enabled = false;
		visuals.enabled = false;
	}

	private void UpdateTimer()
	{
		if (activeTimer > 0)
		{
			// currently active
			activeTimer -= Time.deltaTime;
			if (activeTimer <= 0)
			{
				DisableAbsorb();
			}
		}
		else if (cooldownTimer > 0)
		{
			// currently in cooldown
			cooldownTimer -= Time.deltaTime;
		}
		else
		{
			//Debug.Log("timers done, reset timers and absorbAvailable");
			absorbAvailable = true;
			activeTimer = activeDuration;
			cooldownTimer = cooldownDuration;
		}
	}
}

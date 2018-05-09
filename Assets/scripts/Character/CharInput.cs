using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInput : MonoBehaviour
{
	public bool useController;
	public float deadzoneRadius;
	public float triggerThreshold;

	public Vector2 move = Vector2.zero;
	public Vector2 aim = Vector2.zero;

	public bool jump = false;
	public bool action1 = false;
	public bool action2 = false;
	public bool cleanse = false;
	public bool pause = false;

	public bool jumpDown = false;
	public bool action1Down = false;
	public bool action2Down = false;
	public bool cleanseDown = false;
	public bool pauseDown = false;

	private bool leftTriggerWasDown = false;
	private bool rightTriggerWasDown = false;

	[HideInInspector]
	public Vector2 aimOverwrite = Vector2.zero;

	// Update is called once per frame
	void LateUpdate()
	{
		ResetVars();
		UpdateVars();
	}

	private void ResetVars()
	{
		leftTriggerWasDown = action2;
		rightTriggerWasDown = action1;

		move = Vector2.zero;
		aim = Vector2.zero;

		jump = false;
		action1 = false;
		action2 = false;
		cleanse = false;
		pause = false;

		jumpDown = false;
		action1Down = false;
		action2Down = false;
		cleanseDown = false;
		pauseDown = false;
	}

	private void UpdateVars()
	{
		// movement vector
		move = new Vector2(Input.GetAxisRaw("Move Horizontal"), Input.GetAxisRaw("Move Vertical"));
		if (move.magnitude < deadzoneRadius)
		{
			move = Vector2.zero;
		}

		//aiming vector
		aim = new Vector2(Input.GetAxisRaw("Aim Horizontal"), Input.GetAxisRaw("Aim Vertical"));

		if (aimOverwrite != Vector2.zero)
		{
			aim = aimOverwrite;
			aimOverwrite = Vector2.zero;
		}

		if (aim.magnitude < deadzoneRadius)
		{
			aim = Vector2.zero;
		}

		// jump
		if (Input.GetButton("Jump"))
		{
			jump = true;
		}
		if (Input.GetButtonDown("Jump"))
		{
			jumpDown = true;
		}

		// action 1 (attack action)
		if (Input.GetButton("Action 1") || Input.GetAxisRaw("RightTrigger") > triggerThreshold)
		{
			action1 = true;
		}
		if (Input.GetButtonDown("Action 1") || (action1 && !rightTriggerWasDown))
		{
			action1Down = true;
		}

		// action 2 (movement action)
		if (Input.GetButton("Action 2") || Input.GetAxisRaw("LeftTrigger") > triggerThreshold)
		{
			action2 = true;
		}
		if (Input.GetButtonDown("Action 2") || (action2 && !leftTriggerWasDown) )
		{
			action2Down = true;
		}

		// cleanse (forfeit element)
		if (Input.GetButton("Cleanse"))
		{
			cleanse = true;
		}
		if (Input.GetButtonDown("Cleanse"))
		{
			cleanseDown = true;
		}

		// pause
		if (Input.GetButton("Pause"))
		{
			pause = true;
		}
		if (Input.GetButtonDown("Pause"))
		{
			pauseDown = true;
		}
	}
}

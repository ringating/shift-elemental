using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInput : MonoBehaviour
{
	public bool useController;
	public float deadzoneRadius;
	public Vector2 move = Vector2.zero;
	[HideInInspector]
	public Vector2 aim = Vector2.zero;
	public bool jump = false;
	public bool action1 = false;
	public bool action2 = false;
	public bool cleanse = false;

	public bool jumpDown = false;
	public bool action1Down = false;
	public bool action2Down = false;
	public bool cleanseDown = false;

	// Update is called once per frame
	void LateUpdate()
	{
		ResetVars();
		UpdateVars();
	}

	private void ResetVars()
	{
		move = Vector2.zero;
		aim = Vector2.zero;

		jump = false;
		action1 = false;
		action2 = false;
		cleanse = false;

		jumpDown = false;
		action1Down = false;
		action2Down = false;
		cleanseDown = false;
	}

	private void UpdateVars()
	{
		// movement vector
		move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (move.magnitude < deadzoneRadius)
		{
			move = Vector2.zero;
		}

		//aiming vector
		aim = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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
		if (Input.GetButton("Fire1"))
		{
			action1 = true;
		}
		if (Input.GetButtonDown("Fire1"))
		{
			action1Down = true;
		}

		// action 2 (movement action)
		if (Input.GetButton("Fire2"))
		{
			action2 = true;
		}
		if (Input.GetButtonDown("Fire2"))
		{
			action2Down = true;
		}

		// cleanse (forfeit element)
		if (Input.GetButton("Fire3"))
		{
			cleanse = true;
		}
		if (Input.GetButtonDown("Fire3"))
		{
			cleanseDown = true;
		}

	}
}

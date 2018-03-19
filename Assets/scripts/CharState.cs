using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharState : MonoBehaviour
{
	public int state = 0; // 0 is none, 1 is fire, 2 is ice, 3 is earth
	public int charge = 0;

	public GameObject iceSpear;
	public float iceSpearLaunchOffset;
	public float iceSpearHopSpeed;


	public CharInput input;
	public CharController ctrl;


	public bool facingRight = true;

	// Use this for initialization
	void Start ()
	{
		input = GetComponent<CharInput>();
		ctrl = GetComponent<CharController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (state)
		{
			case 0:
				NoPower();
				break;

			case 1:
				Fire();
				break;

			case 2:
				Ice();
				break;

			case 3:
				Grass();
				break;

			default:
				Debug.Log("invalid state, reverting");
				state = 0;
				break;
		}

		// look in the direction of the movement input vector
		if (0 < input.move.x)
		{
			facingRight = true;
		}
		else if (input.move.x < 0)
		{
			facingRight = false;
		}

		// unless the aim vector is overwriting it
		if (0 < input.aim.x)
		{
			facingRight = true;
		}
		else if (input.aim.x < 0)
		{
			facingRight = false;
		}
	}

	private void NoPower()
	{
		
	}

	private void Fire()
	{

	}

	private void Ice()
	{
		// ice spear
		if (input.action1Down)
		{
			if (facingRight)
			{
				Instantiate(iceSpear, transform.position + new Vector3(iceSpearLaunchOffset,0,0),Quaternion.identity).GetComponent<IceSpear>().goRight = true;
			}
			else
			{
				Instantiate(iceSpear, transform.position + new Vector3(-iceSpearLaunchOffset,0,0), Quaternion.identity).GetComponent<IceSpear>().goRight = false;
			}

			// also jump a tiny bit
			ctrl.IceJump(iceSpearHopSpeed);
		}

		// aoe freeze
		if (input.action2Down)
		{

		}
	}

	private void Grass()
	{

	}

	private void ChangeState()
	{

	}
}

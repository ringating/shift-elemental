using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharState : MonoBehaviour
{
	// general
	public int state = 0; // 0 is none, 1 is fire, 2 is ice, 3 is earth
	public int charge = 0;
	public int maxCharge = 3;

	public CharInput input;
	public CharController ctrl;

	public bool facingRight = true;

	public float maxHealth = 100;
	public float health;

	// default state
	public AbsorbTrigger absorb;
	
	// fire state

	// ice state
	public GameObject iceSpear;
	public float iceSpearLaunchOffset;
	public float iceSpearHopSpeed;

	// grass state
	

	void Start ()
	{
		input = GetComponent<CharInput>();
		ctrl = GetComponent<CharController>();
		health = maxHealth;
	}
	
	void Update ()
	{
		if (charge <= 0)
		{
			state = 0;
		}

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
		// parry/absorb
		if (input.action1)
		{
			absorb.Activate();
		}

		// heal?
		if (input.action2Down){}
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

			// decrement charge
			charge--;
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

	public void Damaged(float damage)
	{
		health -= damage;
	}

	public void Damaged(int damage)
	{
		Damaged((float)damage);
	}
}

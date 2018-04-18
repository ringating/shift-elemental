using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // this probably won't be needed once Die() has been updated

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
	public float healRate;
	
	// fire state
	// (probably not)

	// ice state
	public GameObject iceSpear;
	public float iceSpearLaunchOffset;
	public float iceSpearHopSpeed;

	// grass state
	public GameObject vineGrapple;
	public float vineLaunchOffset;

	// audio
	public AudioSource throwing;
	public AudioSource hurt;
	

	void Start ()
	{
		input = GetComponent<CharInput>();
		ctrl = GetComponent<CharController>();
		health = maxHealth;
	}
	
	void Update ()
	{
		if (health < 0)
		{
			Die();
		}

		if (input.cleanse)
		{
			charge = 0;
			state = 0;
		}

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
		absorb.SetInput(input.action1);

		// heal?
		if (input.action2)
		{
			health += Time.deltaTime * healRate;
			if (health > maxHealth)
			{
				health = maxHealth;
			}
		}
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
				Instantiate(iceSpear, transform.position + new Vector3(iceSpearLaunchOffset,0,0), Quaternion.identity).GetComponent<IceSpear>().goRight = true;
			}
			else
			{
				Instantiate(iceSpear, transform.position + new Vector3(-iceSpearLaunchOffset,0,0), Quaternion.identity).GetComponent<IceSpear>().goRight = false;
			}

			// also jump a tiny bit
			ctrl.IceJump(iceSpearHopSpeed);

			// decrement charge
			charge--;

			// sound
			throwing.Play();
		}

		// aoe freeze
		if (input.action2Down)
		{
			
		}
	}

	private void Grass()
	{
		// melee
		// tbd

		// vine grapple
		if (input.action2Down)
		{
			Instantiate(vineGrapple, transform.position + new Vector3(input.aim.normalized.x * vineLaunchOffset, input.aim.normalized.y * vineLaunchOffset, 0), Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, input.aim))).GetComponent<VineGrapple>().cs = this;
			//charge = 0;
		}

	}

	private void ChangeState()
	{

	}

	public void Damaged(float damage)
	{
		health -= damage;
		hurt.Play();
	}

	public void Damaged(int damage)
	{
		Damaged((float)damage);
	}

	public void Die()
	{
		// this just resets the whole scene atm, change to something more reasonable later
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

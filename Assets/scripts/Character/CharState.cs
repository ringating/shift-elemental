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

	public CheckpointHandler ch;
	public Animator ani;
	public CameraShake camShake;

	// default state
	public AbsorbTrigger absorb;
	//public float healRate;
	public int healCharge = 0;
	public float healAmount;
	public GameObject cantHealSound;
	public GameObject healSound;
	//public GameObject potUIHighlight;
	
	// fire state
	// (probably not)

	// ice state
	public GameObject iceSpear;
	public Vector2 iceSpearLaunchOffset;
	public float iceSpearHopSpeed;

	public GameObject iceBlock;

	// grass state
	public GameObject vineGrapple;
	public float vineLaunchOffset;

	public GameObject betaGrassSpear;

	// audio
	public AudioSource throwing;
	public AudioSource hurt;

	// mask prefabs
	public GameObject iceMaskLost;
	public GameObject grassMaskLost;
	public Transform iceMaskTransform;
	public Transform grassMaskTransform;


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
			
			if (state != 0)
			{
				SpawnMaskParticle();
				charge = 0;
				state = 0;
				ani.SetBool("vine", true);
			}
		}

		if (charge <= 0)
		{
			SpawnMaskParticle(); // only happens if state isn't 0, so no conditional needed
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
		if (input.action2Down)
		{
			if (health < maxHealth && healCharge >= 1)
			{
				//health += Time.deltaTime * healRate;
				//ctrl.Stop();

				healCharge--;
				health += healAmount;
				Instantiate(healSound, transform.position, Quaternion.identity);
			}
			else
			{
				// play sound indicating can't heal
				Instantiate(cantHealSound, transform.position, Quaternion.identity);
			}

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
				Instantiate(iceSpear, transform.position + new Vector3(iceSpearLaunchOffset.x, iceSpearLaunchOffset.y, 0), Quaternion.identity).GetComponent<IceSpear>().goRight = true;
			}
			else
			{
				Instantiate(iceSpear, transform.position + new Vector3(-iceSpearLaunchOffset.x, iceSpearLaunchOffset.y, 0), Quaternion.identity).GetComponent<IceSpear>().goRight = false;
			}

			// also jump a tiny bit
			ctrl.IceJump(iceSpearHopSpeed);

			// decrement charge
			charge--;

			// sound
			throwing.Play();

			// animation
			ani.SetBool("spear", true);
		}

		// ice block
		if (input.action2Down)
		{
			if (facingRight)
			{
				Instantiate(iceBlock, transform.position + new Vector3(iceSpearLaunchOffset.x, iceSpearLaunchOffset.y, 0), Quaternion.identity);
			}
			else
			{
				Instantiate(iceBlock, transform.position + new Vector3(-iceSpearLaunchOffset.x, iceSpearLaunchOffset.y, 0), Quaternion.identity);
			}

			throwing.Play();
			charge--;
			ani.SetBool("summon", true);
		}
	}

	private void Grass()
	{
		// grass attack (spear for now)
		if (input.action1Down)
		{
			if (facingRight)
			{
				Instantiate(betaGrassSpear, transform.position + new Vector3(iceSpearLaunchOffset.x, iceSpearLaunchOffset.y, 0), Quaternion.identity).GetComponent<IceSpear>().goRight = true;
			}
			else
			{
				Instantiate(betaGrassSpear, transform.position + new Vector3(-iceSpearLaunchOffset.x, iceSpearLaunchOffset.y, 0), Quaternion.identity).GetComponent<IceSpear>().goRight = false;
			}

			// also jump a tiny bit
			ctrl.IceJump(iceSpearHopSpeed);

			// decrement charge
			charge--;

			// sound
			throwing.Play();

			// animation
			ani.SetBool("spear", true);
		}

		// vine grapple
		if (input.action2Down && input.aim != Vector2.zero)
		{
			Instantiate(vineGrapple, transform.position + new Vector3(input.aim.normalized.x * vineLaunchOffset, input.aim.normalized.y * vineLaunchOffset, 0), Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, input.aim))).GetComponent<VineGrapple>().cs = this;
			charge--;
			// animation
			ani.SetBool("vine", true);
		}

	}

	private void ChangeState()
	{

	}

	public void Damaged(float damage)
	{
		health -= damage;
		hurt.Play();
		ani.SetBool("damage", true);
		camShake.Shake();
	}

	public void Damaged(int damage)
	{
		Damaged((float)damage);
	}

	public void Die()
	{
		// this just resets the whole scene atm, change to something more reasonable later
		// SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		// hey, here's something more reasonable
		if (ch)
		{
			health = maxHealth;
			charge = 0;
			state = 0;
			ch.Respawn();
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	private void SpawnMaskParticle()
	{
		if (state == 2)
		{
			Instantiate(iceMaskLost, iceMaskTransform.position, iceMaskTransform.rotation);
		}
		else if (state == 3)
		{
			Instantiate(grassMaskLost, grassMaskTransform.position, grassMaskTransform.rotation);
		}
	}
}

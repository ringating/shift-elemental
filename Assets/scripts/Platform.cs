using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	public float leniency = 0.2f; // if too small, player will fall through platform on impact due to collision imprecision
	public BoxCollider2D togglePlat;

	private CharController ch;
	private bool forceDisable = false;
	private float forceDisableTimer = 0;

	void Start ()
	{
		ch = (CharController)FindObjectOfType(typeof(CharController));
	}
	
	void Update ()
	{
		if (!forceDisable)
		{
			if (transform.position.y < (ch.transform.position.y - ch.GetComponent<CapsuleCollider2D>().size.y / 2) + leniency)
			{

				// player is above platform, enable collision between Player1 and Platform layers
				Enable();
			}
			else
			{
				// player is below platform, ignore collision between Player1 and Platform layers
				Disable();
			}
		}
		else
		{
			if (forceDisableTimer > 0)
			{
				forceDisableTimer -= Time.deltaTime;
				Disable();
			}
			else
			{
				forceDisable = false;
				forceDisableTimer = 0;
			}
		}
	}

	public void Enable()
	{
		//Physics2D.IgnoreLayerCollision(8, 9, false);
		togglePlat.enabled = true;
	}

	public void Disable()
	{
		//Physics2D.IgnoreLayerCollision(8, 9, true);
		togglePlat.enabled = false;
	}

	public void Disable(float timer)
	{
		Disable();
		forceDisableTimer = timer;
		forceDisable = true;
	}
}

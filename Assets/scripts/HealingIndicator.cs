using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingIndicator : MonoBehaviour
{
	private SpriteRenderer sr;
	private float prevHealth;
	public CharState cs;

	// public float minOpacity;
	// public float pulsePeriod;

	public float pulseSpeedMultiplier;


	void Start ()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		if (cs.health > prevHealth)
		{
			sr.enabled = true;
		}
		else
		{
			sr.enabled = false;
		}

		sr.color = new Color(1, 1, 1, (Mathf.Sin(Time.time*pulseSpeedMultiplier)+1)/2);

		prevHealth = cs.health;
	}
}

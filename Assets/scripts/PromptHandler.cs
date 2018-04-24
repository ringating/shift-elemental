using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptHandler : MonoBehaviour
{
	public CharState cs;
	public SpriteRenderer neutralPrompt;
	public SpriteRenderer icePrompt;
	public SpriteRenderer grassPrompt;
	public float displayTime;
	public float fadeTime;

	private bool haveSeenNeutral = false;
	private bool haveSeenIce = false;
	private bool haveSeenGrass = false;
	private float neutralOpacity = 1;
	private float iceOpacity = 1;
	private float grassOpacity = 1;
	private float neutralTimer;
	private float iceTimer;
	private float grassTimer;
	private float neutralTimer_f;
	private float iceTimer_f;
	private float grassTimer_f;

	void Start ()
	{
		neutralTimer = displayTime;
		iceTimer = displayTime;
		grassTimer = displayTime;

		neutralTimer_f = fadeTime;
		iceTimer_f = fadeTime;
		grassTimer_f = fadeTime;

		neutralPrompt.enabled = false;
		icePrompt.enabled = false;
		grassPrompt.enabled = false;
	}
	
	void Update ()
	{
		neutralPrompt.color = new Color(1,1,1,neutralOpacity);
		icePrompt.color = new Color(1, 1, 1, iceOpacity);
		grassPrompt.color = new Color(1, 1, 1, grassOpacity);

		if (cs.state == 0) { haveSeenNeutral = true; }
		if (cs.state == 2) { haveSeenIce = true; }
		if (cs.state == 3) { haveSeenGrass = true; }

		if (haveSeenNeutral)
		{
			neutralPrompt.enabled = true;

			if (neutralTimer > 0)
			{
				neutralTimer -= Time.deltaTime;
			}
			else
			{
				neutralTimer_f -= Time.deltaTime;
				if (neutralTimer_f < 0) { neutralTimer_f = 0; }
				neutralOpacity = neutralTimer_f / fadeTime;
			}
		}

		if (haveSeenIce)
		{
			icePrompt.enabled = true;

			if (iceTimer > 0)
			{
				iceTimer -= Time.deltaTime;
			}
			else
			{
				iceTimer_f -= Time.deltaTime;
				if (iceTimer_f < 0) { iceTimer_f = 0; }
				iceOpacity = iceTimer_f / fadeTime;
			}
		}

		if (haveSeenGrass)
		{
			grassPrompt.enabled = true;

			if (grassTimer > 0)
			{
				grassTimer -= Time.deltaTime;
			}
			else
			{
				grassTimer_f -= Time.deltaTime;
				if (grassTimer_f < 0) { grassTimer_f = 0; }
				grassOpacity = grassTimer_f / fadeTime;
			}
		}
	}
}

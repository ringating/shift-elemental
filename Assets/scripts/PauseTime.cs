using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTime : MonoBehaviour
{
	public CharInput input;
	private SpriteRenderer pauseImage;

	void Start ()
	{
		pauseImage = GetComponent<SpriteRenderer>();
		pauseImage.enabled = false;
	}

	void Update ()
	{
		if (input.pauseDown)
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				pauseImage.enabled = true;
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				pauseImage.enabled = false;
			}
		}
	}
}

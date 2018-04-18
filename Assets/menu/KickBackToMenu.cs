﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KickBackToMenu : MonoBehaviour
{
	public float timer;
	
	void Update ()
	{
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			SceneManager.LoadScene("menu");
		}
	}
}

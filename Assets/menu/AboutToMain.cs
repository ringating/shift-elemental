using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutToMain : MonoBehaviour
{
	public MenuManager mm;

	void Update ()
	{
		if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Action 1") || Input.GetButtonDown("Action 2") || Input.GetButtonDown("Cleanse") || Input.GetButtonDown("Pause"))
		{
			mm.main.SetActive(true);

			if (mm.about.activeSelf)
			{
				mm.about.SetActive(false);
			}
			else if (mm.controls.activeSelf)
			{
				mm.controls.SetActive(false);
			}
		}
	}
}

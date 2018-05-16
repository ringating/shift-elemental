using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutToMain : MonoBehaviour
{
	public MenuManager mm;

	void Update ()
	{
		if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Action 1") || Input.GetButtonDown("Action 2") || Input.GetButtonDown("Cleanse") || Input.GetButtonDown("Pause"))
		{
			if (mm.about.activeSelf)
			{
				mm.main.SetActive(true);
				mm.about.SetActive(false);
			}
			else if (mm.controls.activeSelf)
			{
				mm.main.SetActive(true);
				mm.controls.SetActive(false);
			}
			else if (mm.intro.activeSelf)
			{
				SceneManager.LoadScene("beta");
			}
		}
	}
}

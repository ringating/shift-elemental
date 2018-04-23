using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutToMain : MonoBehaviour
{
	public MenuManager mm;

	void Update ()
	{
		if (Input.GetButtonDown("Submit"))
		{
			mm.main.SetActive(true);
			mm.about.SetActive(false);
		}
	}
}

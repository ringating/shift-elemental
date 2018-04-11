using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public void ToGame()
	{
		SceneManager.LoadScene ("ice demo");
	}

	public void ToAbout()
	{
		SceneManager.LoadScene ("about");
	}

	public void Quit()
	{
		Application.Quit ();
	}


}

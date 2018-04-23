using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public GameObject main;
	public GameObject about;

	public void ToGame()
	{
		SceneManager.LoadScene("beta");
	}

	public void ToAbout()
	{
		//SceneManager.LoadScene("about");
		main.SetActive(false);
		about.SetActive(true);
	}

	public void Quit()
	{
		Application.Quit();
	}


}

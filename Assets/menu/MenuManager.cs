using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public GameObject main;
	public GameObject about;
	public GameObject controls;
	public GameObject intro;

	public void ToGame()
	{
		//SceneManager.LoadScene("beta");
		main.SetActive(false);
		intro.SetActive(true);
	}

	public void ToAbout()
	{
		//SceneManager.LoadScene("about");
		main.SetActive(false);
		about.SetActive(true);
	}

	public void ToControls()
	{
		main.SetActive(false);
		controls.SetActive(true);
	}

	public void Quit()
	{
		Application.Quit();
	}


}

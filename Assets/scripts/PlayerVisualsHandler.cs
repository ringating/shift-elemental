using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualsHandler : MonoBehaviour
{
	public CharState cs;

	public GameObject neutralVisuals;
	public GameObject iceVisuals;
	public GameObject grassVisuals;
	
	// Update is called once per frame
	void Update ()
	{
		if (cs.state == 0)
		{
			neutralVisuals.SetActive(true);
			iceVisuals.SetActive(false);
			grassVisuals.SetActive(false);
		}
		else if (cs.state == 2)
		{
			neutralVisuals.SetActive(false);
			iceVisuals.SetActive(true);
			grassVisuals.SetActive(false);
		}
		else if (cs.state == 3)
		{
			neutralVisuals.SetActive(false);
			iceVisuals.SetActive(false);
			grassVisuals.SetActive(true);
		}
	}
}

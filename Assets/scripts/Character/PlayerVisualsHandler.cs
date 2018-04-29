using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spriter2UnityDX;

public class PlayerVisualsHandler : MonoBehaviour
{
	public CharState cs;

	public EntityRenderer neutralVisuals;
	public EntityRenderer iceVisuals;
	public EntityRenderer grassVisuals;
	
	// Update is called once per frame
	void Update ()
	{
		if (cs.state == 0)
		{
			neutralVisuals.enabled = true;
			iceVisuals.enabled = false;
			grassVisuals.enabled = false;
		}
		else if (cs.state == 2)
		{
			neutralVisuals.enabled = false;
			iceVisuals.enabled = true;
			grassVisuals.enabled = false;
		}
		else if (cs.state == 3)
		{
			neutralVisuals.enabled = false;
			iceVisuals.enabled = false;
			grassVisuals.enabled = true;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotHealUI : MonoBehaviour
{
	public Text t;
	public CharState cs;
	public CharInput ci;
	public float colorRecoverRate;
	
	void Update ()
	{
		// only show if in the correct state
		if (cs.state == 0)
		{
			t.enabled = true;
		}
		else
		{
			t.enabled = false;
		}

		// update count
		t.text = "" + cs.healCharge;

		// get whiter unless full white
		if (t.color != Color.white)
		{
			t.color = new Color(1, t.color.g + colorRecoverRate * Time.deltaTime, t.color.b + colorRecoverRate * Time.deltaTime);
		}

		// set color to red if player tries to heal without enough charge
		if (ci.action2Down && cs.healCharge < 1)
		{
			t.color = new Color(1,0,0);
		}
	}
}

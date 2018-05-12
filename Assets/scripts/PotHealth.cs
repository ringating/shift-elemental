using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHealth : MonoBehaviour
{
	private CharState cs;

	public bool GiveCharge()
	{
		cs = (CharState)FindObjectOfType(typeof(CharState));

		if (cs)
		{
			cs.healCharge += 1;
			return true;
		}
		else
		{
			return false;
		}
	}
}

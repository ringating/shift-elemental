using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyHandler : MonoBehaviour
{
	public CharState cs;
	public Butterfly b1;
	public Butterfly b2;
	public Butterfly b3;
	
	void Update ()
	{
		if (cs.charge == 3)
		{
			b1.Show(true);
			b2.Show(true);
			b3.Show(true);
		}
		else if (cs.charge == 2)
		{
			b1.Show(true);
			b2.Show(true);
			b3.Show(false);
		}
		else if (cs.charge == 1)
		{
			b1.Show(true);
			b2.Show(false);
			b3.Show(false);
		}
		else
		{
			b1.Show(false);
			b2.Show(false);
			b3.Show(false);
		}
	}
}

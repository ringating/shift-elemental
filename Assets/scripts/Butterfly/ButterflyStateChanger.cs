using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyStateChanger : MonoBehaviour
{
	public CharState cs;

	public Sprite iceUp;
	public Sprite iceDown;
	public Sprite iceTween;
	public Sprite grassUp;
	public Sprite grassDown;
	public Sprite grassTween;

	public ButterflySpritePicker[] bsp;
	
	void Update ()
	{
		if (cs.state == 2)
		{
			foreach (ButterflySpritePicker b in bsp)
			{
				b.movingUp = iceUp;
				b.movingDown = iceDown;
				b.tween = iceTween;
			}
		}
		else if (cs.state == 3)
		{
			foreach (ButterflySpritePicker b in bsp)
			{
				b.movingUp = grassUp;
				b.movingDown = grassDown;
				b.tween = grassTween;
			}
		}
	}
}

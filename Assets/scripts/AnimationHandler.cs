using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
	public Animator ani;
	public CharController cc;
	public CharState cs;

	public float smallAniTime;

	[SerializeField]
	private float smallTimer;

	void Start ()
	{
		smallTimer = smallAniTime;
	}
	
	void LateUpdate ()
	{
		if (ani.GetBool("damage") || ani.GetBool("summon") || ani.GetBool("spear") || ani.GetBool("vine") || ani.GetBool("block"))
		{
			if (smallTimer > 0)
			{
				smallTimer -= Time.deltaTime;
				if (smallTimer != smallAniTime)
				{
					ani.SetBool("canPlay", false);
				}
			}
			else
			{
				ani.SetBool("damage", false);
				ani.SetBool("summon", false);
				ani.SetBool("spear", false);
				ani.SetBool("vine", false);
				ani.SetBool("block", false);

				smallTimer = smallAniTime;

				ani.SetBool("canPlay", true);
			}
		}
	}
}

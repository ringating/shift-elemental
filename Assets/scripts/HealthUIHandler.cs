using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIHandler : MonoBehaviour
{
	public CharState cs;

	public Sprite flowerOpen;
	public Sprite flowerClosed;
	public Sprite flowerTween;

	public SpriteRenderer[] flowers;

	private float incr;

	private void Start ()
	{
		incr = cs.maxHealth / flowers.Length;
	}

	private void Update ()
	{
		for (int i = 0; i < flowers.Length; i++)
		{
			if (cs.health >= (i + 1) * incr)
			{
				flowers[i].sprite = flowerOpen;
			}
			else if (cs.health >= i * incr)
			{
				flowers[i].sprite = flowerTween;
			}
			else
			{
				flowers[i].sprite = flowerClosed;
			}
		}
	}
}

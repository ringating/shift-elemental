using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUIHandler : MonoBehaviour
{
	public CharState cs;
	public CharInput ci;

	public SpriteRenderer rightIndicator;
	public SpriteRenderer leftIndicator;

	public SpriteRenderer rightAbility;
	public SpriteRenderer leftAbility;

	public Sprite neutral1;
	public Sprite neutral2;
	public Sprite ice1;
	public Sprite ice2;
	public Sprite grass1;
	public Sprite grass2;

	void Start ()
	{
		
	}

	void Update()
	{
		if (ci.action1)
		{
			rightIndicator.enabled = true;
		}
		else
		{
			rightIndicator.enabled = false;
		}

		if (ci.action2)
		{
			leftIndicator.enabled = true;
		}
		else
		{
			leftIndicator.enabled = false;
		}

		switch (cs.state)
		{
			case 0:
				// neutral
				rightAbility.sprite = neutral1;
				leftAbility.sprite = neutral2;
				break;

			case 2:
				// ice
				rightAbility.sprite = ice1;
				leftAbility.sprite = ice2;
				break;

			case 3:
				// grass
				rightAbility.sprite = grass1;
				leftAbility.sprite = grass2;
				break;

			default:
				break;
		}
	}
}

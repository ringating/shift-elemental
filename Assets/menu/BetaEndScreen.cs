using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaEndScreen : MonoBehaviour
{
	public KickBackToMenu kick;
	public SpriteRenderer endScreen;

	void Start ()
	{
		kick.enabled = false;
		endScreen.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.gameObject.SetActive(false);
			kick.enabled = true;
			endScreen.enabled = true;
		}
	}
}

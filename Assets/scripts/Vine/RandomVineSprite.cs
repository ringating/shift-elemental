using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVineSprite : MonoBehaviour
{
	public List<Sprite> sprites;
	private SpriteRenderer sr;

	void Start ()
	{
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = sprites[(int)(Random.value * (sprites.Count - 1))];
	}
}

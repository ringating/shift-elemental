using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleOpacity : MonoBehaviour
{
	public Transform origin;
	public CharController cc;
	private float MaxDistance;
	private float opacity;
	private SpriteRenderer sr;

	void Start ()
	{
		sr = GetComponent<SpriteRenderer>();
		MaxDistance = cc.maxLookDistance;
	}
	
	void Update ()
	{
		opacity = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(origin.position.x, origin.position.y)) / MaxDistance;

		sr.color = new Color(255, 255, 255, opacity);
	}
}

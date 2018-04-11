using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{

	private Vector2 ogPosition;

	private float speed;
	private Vector2 startPosition;
	private float fallTime;

	public float minFallSpeed;
	public float maxFallSpeed;

	public float posSelectionRadius;

	public float minFallTime;
	public float maxFallTime;

	public SpriteRenderer visuals;

	

	void Start ()
	{
		ogPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
		Flap();
	}
	
	void Update ()
	{
		if (fallTime > 0)
		{
			fallTime -= Time.deltaTime;
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - Mathf.Abs(speed)*Time.deltaTime, transform.localPosition.z);
		}
		else
		{
			Flap();
		}
	}

	private void Flap ()
	{
		startPosition = ogPosition + new Vector2(Random.insideUnitCircle.x, Random.insideUnitCircle.y/2) * posSelectionRadius;
		speed = minFallSpeed + Random.value * (maxFallSpeed - minFallSpeed);
		fallTime = minFallTime + Random.value * (maxFallTime - minFallTime);

		transform.localPosition = new Vector3(startPosition.x, startPosition.y, transform.localPosition.z);
	}

	public void Show(bool enable)
	{
		visuals.enabled = enable;
	}
}

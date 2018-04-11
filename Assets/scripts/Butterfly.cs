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
		ogPosition = new Vector2(transform.position.x, transform.position.y);
		Flap();
	}
	
	void Update ()
	{
		if (fallTime > 0)
		{
			fallTime -= Time.deltaTime;
			transform.position = new Vector3(transform.position.x, transform.position.y - Mathf.Abs(speed)*Time.deltaTime, transform.position.z);
		}
		else
		{
			Flap();
		}
	}

	private void Flap ()
	{
		startPosition = ogPosition + Random.insideUnitCircle * posSelectionRadius;
		speed = minFallSpeed + Random.value * (maxFallSpeed - minFallSpeed);
		fallTime = minFallTime + Random.value * (maxFallTime - minFallTime);

		transform.position = new Vector3(startPosition.x, startPosition.y, transform.position.z);
	}

	public void Show(bool enable)
	{
		visuals.enabled = enable;
	}
}

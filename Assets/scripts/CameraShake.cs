using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float maxDistance;
	public float duration;
	public float tickTime;

	private Vector3 ogLocalPos;
	private float timer = 0;
	private int tickCount = 0;
	private int prevTickCount = -1;
	private Vector2 temp;

	void Start ()
	{
		ogLocalPos = transform.localPosition;
		prevTickCount = -1;
	}
	
	void Update ()
	{
		if (timer > 0)
		{
			tickCount = Mathf.RoundToInt((duration - timer) / tickTime);
			Debug.Log("tickCount: " + tickCount);

			if (tickCount != prevTickCount)
			{
				Debug.Log("shake");
				temp = Random.insideUnitCircle.normalized * (timer / duration) * maxDistance;
				transform.localPosition = ogLocalPos + new Vector3(temp.x, temp.y, 0);
			}

			timer -= Time.deltaTime;
			prevTickCount = tickCount;
		}
		else
		{
			timer = 0;
		}
	}

	public void Shake()
	{
		timer = duration;
	}
}

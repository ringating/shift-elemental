using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForceOnStart : MonoBehaviour
{
	public float maxForceMagnitude;
	public float minForceMagnitude;
	public float minTorque;
	public float maxTorque;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(Random.insideUnitCircle.normalized * (minForceMagnitude + Random.value * (maxForceMagnitude - minForceMagnitude)));
		rb.AddTorque(minTorque + Random.value * (maxTorque - minTorque));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLerpIn : MonoBehaviour
{
	// this script should not be used with colliders or rigidbodies, as it affects the actual transform scale and will make collision and physics weird as a result.

	public float lerpAlpha;

	private Vector3 targetScale;
	private float scale = 0;

	void Start ()
	{
		targetScale = transform.localScale;
		transform.localScale = Vector3.zero;
	}
	
	void Update ()
	{
		transform.localScale = targetScale * scale;
		scale = Mathf.Lerp(scale, 1, Mathf.Clamp01(lerpAlpha*Time.deltaTime));
	}
}

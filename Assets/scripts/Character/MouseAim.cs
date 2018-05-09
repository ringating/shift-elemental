using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
	public Camera c;
	public CharInput ci;
	public Transform origin;
	public float timeUntilIgnore;

	private float ignoreTimer = 0;

	private Vector3 prevPos;

	public float aimMultiplier;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
	}

	void Update ()
	{
		if (ignoreTimer > 0)
		{
			// using mouse input
			ci.aimOverwrite = Vector2.ClampMagnitude(aimMultiplier * (Input.mousePosition - c.WorldToScreenPoint(origin.position)), 1f);
		}

		ignoreTimer -= Time.deltaTime;

		if (Input.mousePosition != prevPos)
		{
			ignoreTimer = timeUntilIgnore;
		}

		prevPos = Input.mousePosition;
	}

	void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus)
		{
			Cursor.lockState = CursorLockMode.Confined;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}

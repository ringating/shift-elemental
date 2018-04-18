using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflySpritePicker : MonoBehaviour
{

	public float upCutoff;
	public float downCutoff;
	public float horiFlipDeadZone;

	public Sprite movingUp;
	public Sprite movingDown;
	public Sprite tween;

	private Vector3 prevPos;
	private float vertVel;
	private SpriteRenderer sr;

	private float horiVel;
	private Vector3 rightVec;
	private Vector3 leftVec;

	void Start ()
	{
		prevPos = transform.position;
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = tween;

		rightVec = transform.localScale;
		leftVec = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	void Update ()
	{
		// pick sprite based on vertical vel
		vertVel = (transform.position.y - prevPos.y) / Time.deltaTime;

		if (vertVel > upCutoff)
		{
			sr.sprite = movingUp;
		}
		else if (vertVel < downCutoff)
		{
			sr.sprite = movingDown;
		}
		else
		{
			sr.sprite = tween;
		}


		
		// flip depending on horizontal vel
		horiVel = (transform.position.x - prevPos.x) / Time.deltaTime;

		if (horiVel > horiFlipDeadZone)
		{
			//Debug.Log("butterfly facing right");
			transform.localScale = rightVec;
		}
		else if (horiVel < -horiFlipDeadZone)
		{
			//Debug.Log("butterfly facing left");
			transform.localScale = leftVec;
		}



		prevPos = transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSpearSpeed : MonoBehaviour
{
	public float target;
	public float alpha;
	public IceSpear spear;
	
	// Update is called once per frame
	void Update ()
	{
		spear.speed = Mathf.Lerp(spear.speed, target, alpha * Time.deltaTime);
		spear.speed = Mathf.Lerp(spear.speed, target, alpha * Time.deltaTime);
		spear.speed = Mathf.Lerp(spear.speed, target, alpha * Time.deltaTime);
		spear.speed = Mathf.Lerp(spear.speed, target, alpha * Time.deltaTime);
		spear.speed = Mathf.Lerp(spear.speed, target, alpha * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	public GameObject primarySection;
	public GameObject secondarySection;
	//private GameObject temp; 

	public float sectionWidth;
	public float panScalar;

	private float prevX;

	void Start ()
	{
		panScalar = Mathf.Clamp01(panScalar);

		prevX = transform.position.x;

		primarySection.transform.localPosition = new Vector3(0, primarySection.transform.localPosition.y, primarySection.transform.localPosition.z);
		secondarySection.transform.localPosition = new Vector3(sectionWidth, secondarySection.transform.localPosition.y, secondarySection.transform.localPosition.z);
	}
	
	void Update ()
	{
		primarySection.transform.position += new Vector3((prevX - transform.position.x)*panScalar, 0, 0);
		secondarySection.transform.position += new Vector3((prevX - transform.position.x) * panScalar, 0, 0);

		Overflow(primarySection.transform);
		Overflow(secondarySection.transform);

		prevX = transform.position.x;
	}

	private void Overflow(Transform t)
	{
		if (t.localPosition.x > sectionWidth)
		{
			t.localPosition = new Vector3(-sectionWidth + (t.localPosition.x - sectionWidth), t.localPosition.y, t.localPosition.z);
		}

		if (t.localPosition.x < -sectionWidth)
		{
			t.localPosition = new Vector3(sectionWidth + (t.localPosition.x + sectionWidth), t.localPosition.y, t.localPosition.z);
		}
	}

	/*
	private void Swap()
	{
		temp = primarySection;
		primarySection = secondarySection;
		secondarySection = temp;
	}
	*/
}

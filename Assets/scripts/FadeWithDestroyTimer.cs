using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWithDestroyTimer : MonoBehaviour
{
	public DestroyTimed ds;
	public SpriteRenderer sr;

	private float dur;

	private void Start ()
	{
		dur = ds.timeUntilDestroy;
	}

	private void Update ()
	{
		sr.color = new Color(1,1,1,ds.timeUntilDestroy / dur);
	}
}

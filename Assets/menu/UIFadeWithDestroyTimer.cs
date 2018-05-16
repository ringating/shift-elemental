using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeWithDestroyTimer : MonoBehaviour
{
	public DestroyTimed ds;
	public Image i;

	private float dur;

	private void Start()
	{
		dur = ds.timeUntilDestroy;
	}

	private void Update()
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, ds.timeUntilDestroy / dur);
	}
}

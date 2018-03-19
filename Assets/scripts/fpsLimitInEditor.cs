using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsLimitInEditor : MonoBehaviour
{

	public int fpsLimit = 60;
	
	void Awake()
	{
#if UNITY_EDITOR
		QualitySettings.vSyncCount = 0;  // disable vsync
		Application.targetFrameRate = fpsLimit;
#endif
	}

	private void Update()
	{
#if UNITY_EDITOR
		Application.targetFrameRate = fpsLimit;
#endif
	}
}

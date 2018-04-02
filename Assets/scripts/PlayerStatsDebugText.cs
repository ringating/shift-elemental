using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDebugText : MonoBehaviour
{
	private Text textObj;
	public CharState player;

	// Use this for initialization
	void Start ()
	{
		textObj = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		textObj.text = player.health.ToString() + System.Environment.NewLine + player.charge.ToString();
	}
}

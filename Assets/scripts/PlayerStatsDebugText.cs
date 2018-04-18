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
		textObj.text = ((int)player.health).ToString() + System.Environment.NewLine;

		if (player.state == 0)
		{
			textObj.text += "Neutral";
		}
		else if (player.state == 2)
		{
			textObj.text += "Ice";
		}
		else if (player.state == 3)
		{
			textObj.text += "Grass";
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeDebugText : MonoBehaviour
{
	private Text chargeCount;
	public CharState player;

	// Use this for initialization
	void Start ()
	{
		chargeCount = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		chargeCount.text = player.charge.ToString();
	}
}

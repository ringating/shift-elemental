using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraStateHandler : MonoBehaviour
{

	public int state;

	public GameObject head1;
	public GameObject head2;
	public GameObject head3;
	public DestroyTimed byeHead1;
	public DestroyTimed byeHead2;
	public DestroyTimed byeHead3;
	public DestroyTimed byeHydra;
	public DestroyTimed byeRocks;
	public BoxCollider2D col;

	private bool died = false;

	// Use this for initialization
	void Start ()
	{
		state = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (state)
		{
			case 1:
				// activate second head
				head2.SetActive(true);
				break;

			case 2:
				// activate third head
				head3.SetActive(true);
				break;

			case 3:
				// kill head 1
				if (head1)
				{
					head1.GetComponent<Animator>().SetBool("dead", true);
					byeHead1.enabled = true;
				}
				break;

			case 4:
				// kill head 2
				if (head2)
				{
					head2.GetComponent<Animator>().SetBool("dead", true);
					byeHead2.enabled = true;
				}
				break;

			case 5:
				// kill head 3, drop boulders, activate DestroyTimed script for whole hydra
				if (head3)
				{
					head3.GetComponent<Animator>().SetBool("dead", true);
					byeHead3.enabled = true;
				}

				byeHydra.enabled = true;
				if (byeRocks) { byeRocks.enabled = true; }
				if (col) { Destroy(col); }
				break;

			default:
				break;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSections : MonoBehaviour
{

	public Transform rotationAnchor;
	private Transform player;
	public float length;
	public GameObject vinePart;
	private List<GameObject> parts;

	void Start ()
	{
		player = GetComponent<VineGrapple>().cs.transform;

		parts = new List<GameObject>();

		// spawn first section
		parts.Add(Instantiate(vinePart, rotationAnchor));
		parts[parts.Count - 1].transform.localPosition = new Vector3(-length/2, 0, 0);
	}
	
	void Update ()
	{
		// while count * length < distance between head and player, spawn new
		//while (Vector3.Distance(parts[parts.Count - 1].transform.position, player.position) > length)
		while (parts.Count * length < Vector3.Distance(transform.position,player.position))
		{
			parts.Add(Instantiate(vinePart, rotationAnchor));
			parts[parts.Count - 1].transform.localPosition = parts[parts.Count - 2].transform.localPosition - new Vector3(length,0,0);
		}

		// while count * length > distance between head and player, delete last section
		while (parts.Count * length > Vector3.Distance(transform.position, player.position))
		{
			Destroy(parts[parts.Count - 1]);
			parts.RemoveAt(parts.Count - 1);
		}

	}

	public void Delete()
	{
		// delete properly

	}
}

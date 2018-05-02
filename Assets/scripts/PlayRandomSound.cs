using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
	public AudioSource source;
	public AudioClip[] sounds;

	void Start ()
	{
		RandomPlay();
	}

	public void RandomPlay()
	{
		source.clip = sounds[Random.Range(0, sounds.Length)];
		source.Play();
	}
}

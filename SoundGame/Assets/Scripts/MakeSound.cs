using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MakeSound : MonoBehaviour {

	private AudioClip[] moos;
	private AudioSource sound;
	public string animal;

	// Use this for initialization
	void Start () {
		moos = Resources.LoadAll<AudioClip>("Audio/Actions/" + animal);

		sound = GetComponentInChildren<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!sound.isPlaying && sound.enabled) {
			Sound ();
		}
	}

	void Sound(){
		sound.clip = moos[Random.Range(0, moos.Length)];
		sound.Play();
	}
}
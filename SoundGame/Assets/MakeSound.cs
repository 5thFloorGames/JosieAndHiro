using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MakeSound : MonoBehaviour {

	private AudioClip[] moos;
	private AudioSource sound;
	public string animal;
	public float randomDelay;
	private bool hackflag = false;

	// Use this for initialization
	void Start () {
		moos = Resources.LoadAll<AudioClip>("Audio/Actions/" + animal);

		sound = GetComponentInChildren<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!sound.isPlaying && !hackflag) {
			StartCoroutine("Sound");
		}
	}

	IEnumerator Sound(){
		hackflag = true;
		if(randomDelay != 0){
			yield return new WaitForSeconds (Random.Range(0.2f,randomDelay));
		}
		sound.clip = moos[Random.Range(0, moos.Length)];
		sound.Play();
		hackflag = false;
	}
}
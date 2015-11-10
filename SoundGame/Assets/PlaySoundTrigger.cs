using UnityEngine;
using System.Collections;

public class PlaySoundTrigger : MonoBehaviour {

	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		sound.PlayOneShot(sound.clip);
	}
}

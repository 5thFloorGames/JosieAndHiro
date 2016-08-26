using UnityEngine;
using System.Collections;

public class PauseOnTrigger : MonoBehaviour {

	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		transform.Translate(new Vector3(0f,0f,-0.1f));
		sound.Stop ();
	}

	void OnTriggerExit(Collider other){
		transform.Translate(new Vector3(0f,0f,0.1f));
		sound.Play ();
	}
}

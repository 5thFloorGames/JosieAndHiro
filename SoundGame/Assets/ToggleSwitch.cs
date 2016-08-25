using UnityEngine;
using System.Collections;

public class ToggleSwitch : MonoBehaviour {

	public AudioSource mutable;

	void OnTriggerEnter(Collider other){
		if (!mutable.mute) {
			GetComponent<Renderer> ().material.color = Color.green;
		} else {
			GetComponent<Renderer> ().material.color = Color.white;
		}
		mutable.mute = !mutable.mute;
		transform.Translate(new Vector3(0f,0f,-0.1f));
	}

	void OnTriggerExit(Collider other){
		transform.Translate(new Vector3(0f,0f,0.1f));
	}
}

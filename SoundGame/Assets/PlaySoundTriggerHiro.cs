using UnityEngine;
using System.Collections;

public class PlaySoundTriggerHiro : MonoBehaviour {

	private AudioSource sound;
	
	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Hiro") {
			other.SendMessage ("Click");
		}
	}
}

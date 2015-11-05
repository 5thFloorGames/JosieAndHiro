using UnityEngine;
using System.Collections;

public class PlaySoundTrigger : MonoBehaviour {

	public AudioSource plantSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		plantSound.PlayOneShot(plantSound.clip);
	}
}

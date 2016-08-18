using UnityEngine;
using System.Collections;

public class PlayAttachedSoundOnTrigger : MonoBehaviour {

	private AudioSource sound;
	[SerializeField]
	private Vector4 color;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Josie") {
			sound.PlayOneShot(sound.clip);
		}
		if (other.tag == "Hiro") {
			Renderer renderer = GetComponent<Renderer>();
			renderer.material.color = color;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Hiro") {
			Renderer renderer = GetComponent<Renderer>();
			renderer.material.color = new Vector4(1f,1f,1f,1f);
		}
	}
}

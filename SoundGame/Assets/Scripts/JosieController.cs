using UnityEngine;
using System.Collections;

public class JosieController : MonoBehaviour {
	public float movementSpeed = 10;
	public float turningSpeed = 60;
	private AudioSource sound;
	public AudioClip[] stepSounds;
	public AudioClip signal;

	void Start(){
		sound = gameObject.GetComponent<AudioSource> ();
	}

	void Update() {
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);

		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
			if(!sound.isPlaying){
				sound.clip = stepSounds[Random.Range(0,stepSounds.Length)];
				sound.Play();
			}
		}

		if (Input.GetButton ("Sound")) {
			sound.PlayOneShot(signal);
		}
	}
}
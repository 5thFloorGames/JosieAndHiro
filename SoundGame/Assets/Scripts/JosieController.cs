using UnityEngine;
using System.Collections;

public class JosieController : MonoBehaviour {
	public float movementSpeed = 10;
	public float turningSpeed = 60;
	private AudioSource sound;
	private AudioClip[] stepSounds;
	public AudioClip signal;
	private Animator animator;

	void Start(){
		sound = gameObject.GetComponent<AudioSource> ();
		stepSounds = Resources.LoadAll<AudioClip>("Audio/Josie/");
		animator = GetComponent<Animator> ();
	}

	void Update() {
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);

		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			if(Input.GetAxis ("Vertical") > 0){
				animator.SetBool ("Walking", true);
			} else if (Input.GetAxis ("Vertical") > 0){
				animator.SetBool ("WalkingBackwards", true);
			}
			animator.SetBool ("Walking", true);
			if (!sound.isPlaying) {
				sound.clip = stepSounds [Random.Range (0, stepSounds.Length)];
				sound.Play ();
			}
		} else {
			animator.SetBool ("Walking", false);
			animator.SetBool ("WalkingBackwards", false);
		}

		if (Input.GetButton ("Sound")) {
			sound.PlayOneShot(signal);
		}
	}
}
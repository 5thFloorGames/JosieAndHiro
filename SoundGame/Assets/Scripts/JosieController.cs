using UnityEngine;
using System.Collections;

public class JosieController : MonoBehaviour {
	public float movementSpeed = 10;
	public float turningSpeed = 60;
	public AudioSource sound;
	public AudioSource fallingSound;
	private AudioClip[] stepSounds;
	private AudioClip respawn;
	private Animator animator;
	private bool falling = false;

	void Start(){
		sound = gameObject.GetComponent<AudioSource> ();
		stepSounds = Resources.LoadAll<AudioClip>("Audio/Josie/");
		respawn = Resources.Load<AudioClip> ("Audio/Josie_respawn");
		animator = GetComponent<Animator> ();
		Cursor.visible = false;
		SpawnSound ();
	}

	void Update() {
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);

		if (Input.GetAxis ("Vertical") != 0) {
			if(Input.GetAxis ("Vertical") > 0){
				animator.SetBool ("Walking", true);
			} else if (Input.GetAxis ("Vertical") < 0){
				animator.SetBool ("WalkingBackwards", true);
			}
			if (!sound.isPlaying) {
				sound.clip = stepSounds [Random.Range (0, stepSounds.Length)];
				sound.Play ();
			}
		} else {
			animator.SetBool ("Walking", false);
			animator.SetBool ("WalkingBackwards", false);
		}

		if (transform.position.y < 0 && !falling) {
			falling = true;
			fallingSound.Play();
		}
		
		if (transform.position.y > 0 && falling) {
			falling = false;
		}
	}

	public void reset(){
		animator.SetBool ("Walking", false);
		animator.SetBool ("WalkingBackwards", false);
	}

	public void SpawnSound(){
		sound.PlayOneShot (respawn, 0.3f);
	}
}
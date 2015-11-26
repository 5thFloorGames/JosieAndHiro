using UnityEngine;
using System.Collections;

public class HiroController : MonoBehaviour {
	private float speed = 2.0f;
	private bool rotating = false;
	private bool moving = false;
	private bool falling = false;
	private float rotSpeed = 125.0f;
	private Vector3 target;
	private Light lightSource;
	private AudioSource sound;
	private float rotation = 0.0f;
	private Quaternion qTo = Quaternion.identity;
	private int wallMask = 0;
	public AudioClip[] forwardJumps;
	public AudioClip[] backwardJumps;
	public AudioClip[] turnRight;
	public AudioClip[] turnLeft;
	public AudioClip[] bumps;
	public AudioClip[] fallingSounds;
	public AudioClip[] spawn;

	// Use this for initialization
	void Start () {
		lightSource = GetComponentInChildren<Light> ();
		sound = GetComponentInChildren<AudioSource> ();
		wallMask |= 1 << LayerMask.NameToLayer ("Wall");
		SpawnSound ();
	}

	private void PlayRandomSound(AudioClip[] clips){
		PlayRandomSound(clips,0.4f);
	}

	private void PlayRandomSound(AudioClip[] clips, float volume){
		sound.PlayOneShot (clips[Random.Range(0,clips.Length)], volume);
	}

	public void SpawnSound(){
		PlayRandomSound (spawn, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!rotating && !moving) {
			if (Input.GetButtonDown ("Rotate")) {
				rotation += 90f;
				qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
				Rotate (rotSpeed);
				PlayRandomSound(turnRight);
			} else if (Input.GetButtonDown ("AntiRotate")) {
				rotation -= 90f;
				qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
				Rotate (-rotSpeed);
				PlayRandomSound(turnLeft);
			}
		}
		if (Input.GetButtonDown ("Light")) {
			StartCoroutine("TurnOffAfterSecond");
		}

		if (transform.position.y < 0.5 && !falling) {
			falling = true;
			PlayRandomSound(fallingSounds, 0.8f);
		}

		if (transform.position.y > 0.5 == falling) {
			falling = false;
		}

		if (rotating) {
			transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotSpeed * Time.deltaTime);
			if(Quaternion.Angle(transform.rotation, qTo) < 0.1){
				rotating = false;
			}
		}
		if (moving) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
			if(transform.position == target){
				moving = false;
			}
		}

		if (!rotating && !moving) {
			// Raycast to check for walls.
			if (Input.GetAxis ("HiroHorizontal") < 0) {
				if(Physics.Raycast (transform.position, transform.forward, 1.25f, wallMask)){
					PlayBump();
				} else {
					setTarget(transform.position + transform.forward);
					PlayRandomSound(forwardJumps);
				}
			}
			if (Input.GetAxis ("HiroHorizontal") > 0) {
				if(Physics.Raycast (transform.position, transform.forward * (-1), 1.25f, wallMask)){
					// make this play only once
					PlayBump();
				} else {
					setTarget(transform.position + transform.forward * (-1));
					PlayRandomSound(backwardJumps);
				}
			}
		}
	}

	void PlayBump(){
		if (!sound.isPlaying) {
			sound.clip = bumps[Random.Range(0,bumps.Length)];
			sound.Play();
		}
	}

	IEnumerator TurnOffAfterSecond() {
		lightSource.enabled = true;
		yield return new WaitForSeconds(1);
		lightSource.enabled = false;
	}

	void Rotate(float speed) {
		rotating = true;
	}

	void setTarget(Vector3 transform){
		target = transform;
		moving = true;
	}

	public void reset(){
		rotating = false;
		 moving = false;
	}
}
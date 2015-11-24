using UnityEngine;
using System.Collections;

public class HiroController : MonoBehaviour {
	private float speed = 2.0f;
	private bool rotating = false;
	private bool moving = false;
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

	// Use this for initialization
	void Start () {
		lightSource = GetComponentInChildren<Light> ();
		sound = GetComponentInChildren<AudioSource> ();
		wallMask |= 1 << LayerMask.NameToLayer ("Wall");
	}

	private void PlayRandomSound(AudioClip[] clips){
		sound.PlayOneShot (clips[Random.Range(0,clips.Length)]);
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
					PlayRandomSound(bumps);
				} else {
					setTarget(transform.position + transform.forward);
					PlayRandomSound(forwardJumps);
				}
			}
			if (Input.GetAxis ("HiroHorizontal") > 0) {
				if(Physics.Raycast (transform.position, transform.forward * (-1), 1.25f, wallMask)){
					PlayRandomSound(bumps);
				} else {
					setTarget(transform.position + transform.forward * (-1));
					PlayRandomSound(backwardJumps);
				}
			}
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
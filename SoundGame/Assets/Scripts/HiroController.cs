using UnityEngine;
using System.Collections;

public class HiroController : MonoBehaviour {
	private float speed = 2.0f;
	private bool rotating = false;
	private bool moving = false;
	public float rotSpeed = 100.0f;
	private Vector3 target;
	private Light lightSource;
	private float rotation = 0.0f;
	private Quaternion qTo = Quaternion.identity;
	private int wallMask = 0;

	// Use this for initialization
	void Start () {
		lightSource = GetComponentInChildren<Light> ();
		wallMask |= 1 << LayerMask.NameToLayer ("Wall");
	}
	
	// Update is called once per frame
	void Update () {
		if (!rotating && !moving) {
			if (Input.GetButtonDown ("Rotate")) {
				rotation += 90f;
				qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
				Rotate (rotSpeed);
			} else if (Input.GetButtonDown ("AntiRotate")) {
				rotation -= 90f;
				qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
				Rotate (-rotSpeed);
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
					// play a sound and move forward and back a bit maybe.
				} else {
					setTarget(transform.position + transform.forward);
				}
			}
			if (Input.GetAxis ("HiroHorizontal") > 0) {
				if(Physics.Raycast (transform.position, transform.forward * (-1), 1.25f, wallMask)){
					// play a sound and move forward and back a bit maybe.
				} else {
					setTarget(transform.position + transform.forward * (-1));
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
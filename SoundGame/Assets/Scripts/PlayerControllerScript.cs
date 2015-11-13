using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
	private float speed = 2.0f;
	public int maxspeed = 5;
	private Rigidbody rigid;
	private bool rotating = false;
	private bool moving = false;
	private float rotSpeed = 2.0f;
	private int frameCounter = 0;
	private Vector3 target;
	private Light lightSource;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		lightSource = GetComponentInChildren<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!rotating && !moving) {
			if (Input.GetButton ("Rotate")) {
				Rotate (3.0f);
			} else if (Input.GetButton ("AntiRotate")) {
				Rotate (-3.0f);
			}
		}
		if (Input.GetButtonDown ("Light")) {
			StartCoroutine("TurnOffAfterThree");
		}

		if (rotating) {
			transform.Rotate (0, rotSpeed, 0);
			frameCounter++;
			if(frameCounter >= 30){
				frameCounter = 0;
				rotating = false;
			}
		}
		if (moving) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target, step);
			if(transform.position == target){
				print (frameCounter);
			}
			frameCounter++;
			if(frameCounter >= 30){
				frameCounter = 0;
				moving = false;
			}
		}
		if (!rotating && !moving) {
			if (Input.GetAxis ("HiroHorizontal") < 0) {
				setTarget(transform.position + transform.forward);
			}
			if (Input.GetAxis ("HiroHorizontal") > 0) {
				setTarget(transform.position + transform.forward * (-1));
			}
			if (Input.GetAxis ("HiroVertical") < 0) {
				setTarget(transform.position + transform.right * (-1));
			}
			if (Input.GetAxis ("HiroVertical") > 0) {
				setTarget(transform.position + transform.right);

			}
		}
	}

	IEnumerator TurnOffAfterThree() {
		lightSource.enabled = true;
		yield return new WaitForSeconds(1);
		lightSource.enabled = false;
	}

	void Rotate(float speed) {
		rotating = true;
		rotSpeed = speed;
	}

	void setTarget(Vector3 transform){
		target = transform;
		moving = true;
	}
}
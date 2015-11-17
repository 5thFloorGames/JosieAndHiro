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

	// Use this for initialization
	void Start () {
		lightSource = GetComponentInChildren<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!rotating && !moving) {
			if (Input.GetButton ("Rotate")) {
				rotation += 90f;
				qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
				Rotate (rotSpeed);
			} else if (Input.GetButton ("AntiRotate")) {
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
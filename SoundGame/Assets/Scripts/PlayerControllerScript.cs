using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
	private int speed = 50;
	public int maxspeed = 5;
	private Rigidbody rigid;
	private bool rotating = false;
	private float rotSpeed = 2.0f;
	private int frameCounter = 0;

	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!rotating) {
			if (Input.GetButton ("Rotate")) {
				Rotate (3.0f);
			} else if (Input.GetButton ("AntiRotate")) {
				Rotate (-3.0f);
			}
		}
		if (rotating) {
			transform.Rotate (0, rotSpeed, 0);
			frameCounter++;
			if(frameCounter >= 30){
				frameCounter = 0;
				rotating = false;
			}
		} 
		//if (rigid.velocity == Vector3.zero) {
			if (Input.GetAxis ("HiroHorizontal") < 0) {
				if (rigid.velocity.magnitude < maxspeed)
					rigid.AddForce (rigid.rotation * new Vector3 (0, 0, speed));
			}
			if (Input.GetAxis ("HiroHorizontal") > 0) {
				if (GetComponent<Rigidbody> ().velocity.magnitude < maxspeed)
					rigid.AddForce (rigid.rotation * new Vector3 (0, 0, (-1) * speed));
			}
			if (Input.GetAxis ("HiroVertical") < 0) {
				if (GetComponent<Rigidbody> ().velocity.magnitude < maxspeed)
					rigid.AddForce (rigid.rotation * new Vector3 ((-1) * speed, 0, 0));
			}
			if (Input.GetAxis ("HiroVertical") > 0) {
				if (GetComponent<Rigidbody> ().velocity.magnitude < maxspeed)
					rigid.AddForce (rigid.rotation * new Vector3 (speed, 0, 0));
			}
		//}
	}


	void Rotate(float speed) {
		rotating = true;
		rotSpeed = speed;
	}
}
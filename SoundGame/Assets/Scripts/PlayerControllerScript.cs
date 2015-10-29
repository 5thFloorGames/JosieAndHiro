using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
	private int speed = 50;
	public int maxspeed = 5;
	private Rigidbody rigid;
	
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate() {
		if (Input.GetAxis ("HiroHorizontal") < 0){
			if(rigid.velocity.magnitude < maxspeed)
				rigid.AddForce (new Vector3(0, 0, speed));
		}
		if (Input.GetAxis ("HiroHorizontal") > 0){
			if(GetComponent<Rigidbody>().velocity.magnitude < maxspeed)
				rigid.AddForce (new Vector3(0, 0, (-1) * speed));
		}
		if (Input.GetAxis ("HiroVertical") < 0 ){
			if(GetComponent<Rigidbody>().velocity.magnitude < maxspeed)
				rigid.AddForce (new Vector3((-1) * speed, 0, 0));
		}
		if (Input.GetAxis ("HiroVertical") > 0 ){
			if(GetComponent<Rigidbody>().velocity.magnitude < maxspeed)
				rigid.AddForce (new Vector3(speed, 0, 0));
		}
	}
}
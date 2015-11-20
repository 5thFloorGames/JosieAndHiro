using UnityEngine;
using System.Collections;

public class DoorLift : MonoBehaviour {

	private bool opening = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			Vector3 target = new Vector3 (transform.position.x, -2f, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, target, 1f * Time.deltaTime);
			if(transform.position == target){
				opening = false;
			}
		}
	}

	public void Open(){
		opening = true;
	}
}

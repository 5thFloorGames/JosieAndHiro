using UnityEngine;
using System.Collections;

public class ToggleDoor : MonoBehaviour {

	public DoorOpen door;
	private bool occupied = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie" && !occupied) {
			door.Open();
			occupied = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie" && !occupied) {
			door.Close();
			occupied = false;
		}
	}	
}

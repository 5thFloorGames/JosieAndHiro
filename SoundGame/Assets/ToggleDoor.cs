using UnityEngine;
using System.Collections;

public class ToggleDoor : MonoBehaviour {

	public DoorOpen door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie") {
			door.Open();
		}
		print ("entering");
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie") {
			door.Close();
		}
		print ("leaving");
	}	
}

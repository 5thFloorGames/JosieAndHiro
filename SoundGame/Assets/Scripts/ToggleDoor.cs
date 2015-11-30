using UnityEngine;
using System.Collections;

public class ToggleDoor : MonoBehaviour {

	public DoorOpen door;
	private bool occupied = false;
	private bool doubleOccupied = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if ((other.tag == "Hiro" || other.tag == "Josie") && !occupied) {
			door.Open();
			occupied = true;
		} else if ((other.tag == "Hiro" || other.tag == "Josie") && occupied) {
			doubleOccupied = true;
			print ("double!");
		}
	}
	
	void OnTriggerExit(Collider other){
		if ((other.tag == "Hiro" || other.tag == "Josie") && !doubleOccupied) {
			door.Close();
			occupied = false;
		} else if ((other.tag == "Hiro" || other.tag == "Josie") && doubleOccupied) {
			doubleOccupied = false;
			print ("double!");
		}
	}	
}

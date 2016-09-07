using UnityEngine;
using System.Collections;

public class ToggleMultipleDoors : MonoBehaviour {

	public DoorOpen[] doors;
	private AudioSource sound;
	public Player activatableBy;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		if (checkPlayer (other)) {
			foreach (DoorOpen door in doors) {
				door.Open();
			}		
		}
	}

	void OnTriggerExit(Collider other){
		if (checkPlayer(other)) {
			foreach (DoorOpen door in doors) {
				door.Close ();
			}
		}
	}	

	private bool checkPlayer(Collider other){
		if (activatableBy == Player.Hiro) {
			return other.tag == "Hiro";
		} else if (activatableBy == Player.Josie) {
			return other.tag == "Josie";
		} else {
			return (other.tag == "Hiro" || other.tag == "Josie");
		}
	}
}
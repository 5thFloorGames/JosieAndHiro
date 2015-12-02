using UnityEngine;
using System.Collections;

public class ToggleDoor : MonoBehaviour {

	public DoorOpen door;
	private bool occupied = false;
	private bool doubleOccupied = false;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	void OnTriggerEnter(Collider other){
		if ((other.tag == "Hiro" || other.tag == "Josie") && !occupied) {
			occupied = true;
			StartCoroutine(ClickAndOpen(other));
		} else if ((other.tag == "Hiro" || other.tag == "Josie") && occupied) {
			doubleOccupied = true;
			print ("double!");
		}
	}

	IEnumerator ClickAndOpen(Collider other){
		if (other.tag == "Hiro") {
			yield return new WaitForSeconds(0.75f);
			other.SendMessage ("Click");
		} else {
			yield return new WaitForSeconds(0.5f);
			sound.PlayOneShot(sound.clip);
		}
		door.Open();
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

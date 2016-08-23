using UnityEngine;
using System.Collections;

public class ToggleDoor : MonoBehaviour {
	
	public DoorOpen door;
	private bool occupied = false;
	private bool doubleOccupied = false;
	private AudioSource sound;
	public Player activatableBy;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	void OnTriggerEnter(Collider other){
		if (checkPlayer(other) && !occupied) {
			occupied = true;
			StartCoroutine(ClickAndOpen(other));
		} else if (checkPlayer(other) && occupied) {
			doubleOccupied = true;
			print ("double!");
		}
	}

	IEnumerator ClickAndOpen(Collider other){
		if (other.tag == "Hiro" && (activatableBy == Player.Hiro || activatableBy == Player.Both)) {
			yield return new WaitForSeconds(0.75f);
			other.SendMessage ("Click");
		} else if(activatableBy == Player.Josie || activatableBy == Player.Both) {
			yield return new WaitForSeconds(0.1f);
			sound.PlayOneShot(sound.clip);
		}
		door.Open();
	}
	
	void OnTriggerExit(Collider other){
		print("exittrigger");
		if (checkPlayer(other) && !doubleOccupied) {
			door.Close();
			print ("closing");
			occupied = false;
			transform.Translate(new Vector3(0f,0f,0.1f));
		} else if (checkPlayer(other) && doubleOccupied) {
			doubleOccupied = false;
			print ("double!");
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
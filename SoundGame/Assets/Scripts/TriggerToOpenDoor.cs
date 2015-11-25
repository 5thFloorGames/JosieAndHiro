using UnityEngine;
using System.Collections;

public class TriggerToOpenDoor : MonoBehaviour {

	public DoorOpen door;
	private int playersInTrigger = 0;
	private AudioClip success;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie") {
			playersInTrigger++;
			if(playersInTrigger == 2){
				sound.PlayOneShot(success);
				door.Open();
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie") {
			playersInTrigger--;
		}
	}
}

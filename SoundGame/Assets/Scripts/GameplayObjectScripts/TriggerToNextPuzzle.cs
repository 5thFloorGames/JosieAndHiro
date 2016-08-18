using UnityEngine;
using System.Collections;

public class TriggerToNextPuzzle : MonoBehaviour {
	
	public DoorOpen door;
	private int playersInTrigger = 0;
	private AudioSource sound;
	public GameObject enable;
	public GameObject[] turnoff;
	
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
				StartCoroutine("Activate");
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Hiro" || other.tag == "Josie") {
			playersInTrigger--;
		}
	}
	
	void Enable(){
		enable.SetActive (true);
	}

	void TurnOff(){
		foreach (GameObject g in turnoff) {
			g.SetActive(false);
		}
	}
	
	IEnumerator Activate(){
		yield return new WaitForSeconds (0.2f);
		door.Open();
		yield return new WaitForSeconds (0.5f);
		Enable();
		TurnOff ();
	}
}

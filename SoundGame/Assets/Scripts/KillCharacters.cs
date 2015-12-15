using UnityEngine;
using System.Collections;

public class KillCharacters : MonoBehaviour {

	public Transform JosieSpawn;
	public Transform HiroSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			Application.LoadLevel(0);
		}
		if (Input.GetKeyDown(KeyCode.O)) {
			Application.LoadLevel(1);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Hiro") {
			other.GetComponent<HiroController>().reset();
			other.transform.position = HiroSpawn.position; 
			other.SendMessage("SpawnSound");
		} else if (other.tag == "Josie") {
			other.transform.position = JosieSpawn.position;
			other.SendMessage("SpawnSound");
		}
	}
}

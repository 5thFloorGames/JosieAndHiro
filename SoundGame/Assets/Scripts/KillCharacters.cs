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
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Hiro") {
			other.GetComponent<HiroController>().reset();
			other.transform.position = HiroSpawn.position; 
			other.SendMessage("SpawnSound");
		} else if (other.tag == "Josie") {
			other.transform.position = JosieSpawn.position;
		}
	}
}

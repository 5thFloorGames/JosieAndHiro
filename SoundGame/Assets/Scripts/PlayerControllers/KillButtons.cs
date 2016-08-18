using UnityEngine;
using System.Collections;

public class KillButtons : MonoBehaviour {

	public Transform HiroSpawn;
	public Transform JosieSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Kill buttons for getting stuck
		if (Input.GetButtonDown ("KillHiro")) {
			GameObject other = GameObject.FindGameObjectWithTag("Hiro");
			other.GetComponent<HiroController>().reset();
			other.transform.position = HiroSpawn.position; 
			other.SendMessage("SpawnSound");
		} else if (Input.GetButtonDown ("KillJosie")) {
			GameObject other = GameObject.FindGameObjectWithTag("Josie");
			other.transform.position = JosieSpawn.position;
		}
	}
}

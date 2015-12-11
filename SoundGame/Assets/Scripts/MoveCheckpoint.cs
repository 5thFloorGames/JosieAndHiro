using UnityEngine;
using System.Collections;

public class MoveCheckpoint : MonoBehaviour {

	public GameObject movableCheckpoint;
	public Player activatableBy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == activatableBy.ToString()) {
			movableCheckpoint.transform.position = transform.position;
		}
	}

}
using UnityEngine;
using System.Collections;

public class MoveCheckpoint : MonoBehaviour {

	public GameObject movableCheckpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		movableCheckpoint.transform.position = transform.position;
	}

}
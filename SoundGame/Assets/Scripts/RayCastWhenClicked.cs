using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayCastWhenClicked : MonoBehaviour {

	public float distance  = 10f;
	private GameObject[] guards;

	// Use this for initialization
	void Start () {
		guards = GameObject.FindGameObjectsWithTag("Guard");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		RaycastHit hit;
		foreach (GameObject guard in guards) {
			if (Physics.Raycast (transform.position, guard.transform.position - transform.position, out hit, distance)) {
				hit.collider.gameObject.GetComponent<MoveWhenSound> ().SetDestination (transform.position);
			}
		}
	}
	
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, distance);
	}
}
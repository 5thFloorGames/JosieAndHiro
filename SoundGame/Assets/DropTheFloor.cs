using UnityEngine;
using System.Collections;

public class DropTheFloor : MonoBehaviour {

	private Vector3 originalPosition;
	private bool drop = false;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		StartCoroutine ("DropTheFloorManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (drop) {
			Vector3 target = transform.position + Vector3.down;
			transform.position = Vector3.MoveTowards (transform.position, target, 10f * Time.deltaTime);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, originalPosition, 20f * Time.deltaTime);
		}
	}

	IEnumerator DropTheFloorManager() {
		while (true) {
			yield return new WaitForSeconds (5);
			drop = true;
			yield return new WaitForSeconds (5);
			drop = false;
			yield return new WaitForSeconds (5);
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropTheFloor : MonoBehaviour {

	enum State{Up, Down, Inactive};

	private Vector3 originalPosition;
	private State drop = State.Inactive;
	public GameObject[] greens;
	public GameObject[] oranges;
	private int dropIndex = 0;
	private List<GameObject[]> droppables;
	
	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		StartCoroutine ("DropTheFloorManager");
		droppables = new List<GameObject[]> ();
		droppables.Add (greens);
		droppables.Add (oranges);
	}
	
	// Update is called once per frame
	void Update () {
		if (drop == State.Down) {
			Vector3 target = new Vector3(transform.position.x, -10f, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, target, 10f * Time.deltaTime);
			foreach(GameObject g in droppables[dropIndex]){
				target = new Vector3(g.transform.position.x, -14.49f, g.transform.position.z);
				g.transform.position = Vector3.MoveTowards (g.transform.position, target, 10f * Time.deltaTime);
			}
		} else if (drop == State.Up) {
			if(transform.position.y < 0) {
				transform.position = Vector3.MoveTowards (transform.position, originalPosition, 10f * Time.deltaTime);
			} else {
				transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			}
			foreach(GameObject g in droppables[dropIndex]){
				Vector3 target = new Vector3(g.transform.position.x, -4.49f, g.transform.position.z);
				if(g.transform.position.y < -4.49) {
					g.transform.position = Vector3.MoveTowards (g.transform.position, target, 10f * Time.deltaTime);
				} else {
					g.transform.position = new Vector3(g.transform.position.x, -4.49f, g.transform.position.z);
				}
				// Fix so it goes back to their original positions
			}
		}
	}

	IEnumerator DropTheFloorManager() {
		while (true) {
			yield return new WaitForSeconds (5);
			dropIndex = (int)Mathf.Round(Random.value);
			drop = State.Down;
			yield return new WaitForSeconds (3);
			drop = State.Up;
			yield return new WaitForSeconds (3);
			drop = State.Inactive;
		}
	}
}

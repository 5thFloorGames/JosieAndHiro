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
			Vector3 target = transform.position + Vector3.down;
			transform.position = Vector3.MoveTowards (transform.position, target, 10f * Time.deltaTime);
			foreach(GameObject g in droppables[dropIndex]){
				target = g.transform.position + Vector3.down;
				g.transform.position = Vector3.MoveTowards (g.transform.position, target, 10f * Time.deltaTime);
			}
		} else if (drop == State.Up) {
			transform.position = Vector3.MoveTowards (transform.position, originalPosition, 10f * Time.deltaTime);
			foreach(GameObject g in droppables[dropIndex]){
				Vector3 target = g.transform.position + Vector3.up;
				g.transform.position = Vector3.MoveTowards (g.transform.position, target, 10f * Time.deltaTime);
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

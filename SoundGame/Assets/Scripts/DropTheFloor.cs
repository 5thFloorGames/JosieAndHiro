using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropTheFloor : MonoBehaviour {

	enum State{Up, Down, Inactive};

	private Vector3 originalPosition;
	private State drop = State.Inactive;
	private int dropIndex = 0;
	private int maxBlocks = 0;
	private List<GameObject[]> droppables;
	private AudioSource sound;
	private float[] pitches = {0.5f,0.7f, 0.9f};
	
	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
		originalPosition = transform.position;
		StartCoroutine ("DropTheFloorManager");
		droppables = new List<GameObject[]> ();
		AddBlocks("Green");
		AddBlocks("Orange");
		AddBlocks("Red");
	}

	private void AddBlocks(string tag){
		GameObject[] blocks = GameObject.FindGameObjectsWithTag (tag);
		if (blocks.Length != 0) {
			droppables.Add(blocks);
			maxBlocks++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (drop == State.Down) {
			Vector3 target = new Vector3(transform.position.x, -10f, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, target, 10f * Time.deltaTime);
			dropAllButThis();
		} else if (drop == State.Up) {
			if(transform.position.y < 0) {
				transform.position = Vector3.MoveTowards (transform.position, originalPosition, 10f * Time.deltaTime);
			} else {
				transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			}
			liftAllButThis();
		}
	}

	private void liftAllButThis(){
		for (int i = 0; i < maxBlocks; i++) {
			if(i != dropIndex){
				liftBlocksAtIndex(i);
			}
		}
	}

	private void dropAllButThis(){
		for (int i = 0; i < maxBlocks; i++) {
			if(i != dropIndex){
				dropBlocksAtIndex(i);
			}
		}
	}

	private void dropBlocksAtIndex(int index){
		foreach(GameObject g in droppables[index]){
			Vector3 target = new Vector3(g.transform.position.x, -14.49f, g.transform.position.z);
			g.transform.position = Vector3.MoveTowards (g.transform.position, target, 10f * Time.deltaTime);
		}
	}

	private void liftBlocksAtIndex(int index){
		foreach(GameObject g in droppables[index]){
			Vector3 target = new Vector3(g.transform.position.x, -4.49f, g.transform.position.z);
			if(g.transform.position.y < -4.49) {
				g.transform.position = Vector3.MoveTowards (g.transform.position, target, 10f * Time.deltaTime);
			} else {
				g.transform.position = new Vector3(g.transform.position.x, -4.49f, g.transform.position.z);
			}
		}
	}

	IEnumerator DropTheFloorManager() {
		yield return new WaitForSeconds (1);
		while (true) {
			dropIndex = Random.Range(0,maxBlocks);
			sound.pitch = pitches[dropIndex];
			sound.PlayOneShot(sound.clip);
			yield return new WaitForSeconds (1);
			drop = State.Down;
			yield return new WaitForSeconds (3);
			drop = State.Up;
			yield return new WaitForSeconds (3);
			drop = State.Inactive;
			yield return new WaitForSeconds (Random.Range(1,5));
		}
	}
}

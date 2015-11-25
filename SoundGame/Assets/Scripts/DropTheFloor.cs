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
	[SerializeField]
	private AudioClip countDown;
	[SerializeField]
	private AudioClip floorsDown;
	[SerializeField]
	private AudioClip floorsUp;
	[SerializeField]
	private AudioClip[] clips;
	public float moverate = 10f;
	
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
			transform.position = Vector3.MoveTowards (transform.position, target, moverate * Time.deltaTime);
			dropAllButThis();
		} else if (drop == State.Up) {
			if(transform.position.y < 0) {
				transform.position = Vector3.MoveTowards (transform.position, originalPosition, moverate * Time.deltaTime);
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
			g.transform.position = Vector3.MoveTowards (g.transform.position, target, moverate * Time.deltaTime);
		}
	}

	private void liftBlocksAtIndex(int index){
		foreach(GameObject g in droppables[index]){
			Vector3 target = new Vector3(g.transform.position.x, -4.49f, g.transform.position.z);
			if(g.transform.position.y < -4.49) {
				g.transform.position = Vector3.MoveTowards (g.transform.position, target, moverate * Time.deltaTime);
			} else {
				g.transform.position = new Vector3(g.transform.position.x, -4.49f, g.transform.position.z);
			}
		}
	}

	IEnumerator DropTheFloorManager() {
		yield return new WaitForSeconds (1);
		while (true) {
			dropIndex = Random.Range(0,maxBlocks);
			sound.PlayOneShot(clips[dropIndex]);
			yield return new WaitForSeconds (0.5f);
			sound.PlayOneShot(countDown,0.2f);
			yield return new WaitForSeconds (6);
			drop = State.Down;
			sound.PlayOneShot(floorsDown);
			yield return new WaitForSeconds (3);
			sound.PlayOneShot(floorsUp);
			drop = State.Up;
			yield return new WaitForSeconds (3);
			drop = State.Inactive;
			yield return new WaitForSeconds (Random.Range(2,6));
		}
	}
}

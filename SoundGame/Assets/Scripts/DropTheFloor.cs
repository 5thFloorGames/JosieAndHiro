﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropTheFloor : MonoBehaviour {
	
	private Vector3 originalPosition;
	private int maxBlocks = 3;
	[SerializeField]
	private GameObject[] droppables;
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
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void liftAllButThis(int dropIndex){
		for (int i = 0; i < maxBlocks; i++) {
			if(i != dropIndex){
				StartCoroutine(liftBlocksAtIndex(i));
			}
		}
	}

	private void dropAllButThis(int dropIndex){
		for (int i = 0; i < maxBlocks; i++) {
			if(i != dropIndex){
				StartCoroutine(dropBlocksAtIndex(i));
			}
		}
	}

	IEnumerator dropBlocksAtIndex(int index){
		bool done = false;
		while (!done) {
			print ("status: " + done);
			GameObject g = droppables [index];
			Vector3 target = new Vector3 (g.transform.position.x, -10f, g.transform.position.z);
			g.transform.position = Vector3.MoveTowards (g.transform.position, target, moverate * Time.deltaTime);
			if (g.transform.position.y <= -10) {
				print ("perillä");
				done = true;
			} else {
				yield return null;
			}
		}
	}

	IEnumerator liftBlocksAtIndex(int index){
		bool done = false;
		while (!done) {
			print ("status: " + done);
			GameObject g = droppables [index];
			Vector3 target = new Vector3 (g.transform.position.x, 0f, g.transform.position.z);
			if (g.transform.position.y < 0) {
				print ("liikutaan");
				g.transform.position = Vector3.MoveTowards (g.transform.position, target, moverate * Time.deltaTime);
				yield return null;
			} else {
				g.transform.position = new Vector3 (g.transform.position.x, 0f, g.transform.position.z);
				print ("perillä");
				done = true;
			}
		}
	}

	IEnumerator DropTheFloorManager() {
		yield return new WaitForSeconds (2);
		int dropIndex2 = Random.Range (0, maxBlocks);
		while (true) {
			int dropIndex = dropIndex2;
			while(dropIndex == dropIndex2){
				dropIndex2 = Random.Range(0,maxBlocks);
			}
			print("palikka1: " + dropIndex + " palikka2: " + dropIndex2);
			sound.PlayOneShot(clips[dropIndex]);
			yield return new WaitForSeconds (0.5f);
			sound.PlayOneShot(countDown,0.2f);
			yield return new WaitForSeconds (6);
			dropAllButThis(dropIndex);
			sound.PlayOneShot(floorsDown);
			yield return new WaitForSeconds (3);
			sound.PlayOneShot(floorsUp);
			StartCoroutine(liftBlocksAtIndex(dropIndex2));
			yield return new WaitForSeconds (3);
			yield return new WaitForSeconds (Random.Range(1f,2f));
		}
	}
}

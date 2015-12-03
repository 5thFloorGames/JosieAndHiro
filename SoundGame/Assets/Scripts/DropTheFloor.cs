using UnityEngine;
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
	private List<AudioClip[]> clips;
	public float moverate = 10f;
	
	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource> ();
		originalPosition = transform.position;
		clips = new List<AudioClip[]> ();
		clips.Add(Resources.LoadAll<AudioClip>("Audio/Actions/Cat"));
		clips.Add(Resources.LoadAll<AudioClip>("Audio/Actions/Dog"));
		clips.Add(Resources.LoadAll<AudioClip>("Audio/Actions/Cow"));
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
			GameObject g = droppables [index];
			Vector3 target = new Vector3 (g.transform.position.x, -10f, g.transform.position.z);
			g.transform.position = Vector3.MoveTowards (g.transform.position, target, moverate * Time.deltaTime);
			if (g.transform.position.y <= -10) {
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
				g.transform.position = Vector3.MoveTowards (g.transform.position, target, moverate * Time.deltaTime);
				yield return null;
			} else {
				g.transform.position = new Vector3 (g.transform.position.x, 0f, g.transform.position.z);
				done = true;
			}
		}
	}

	void PlayRandomSound(AudioClip[] clips, float volume){
		sound.PlayOneShot (clips[Random.Range(0, clips.Length)], volume);
	}

	IEnumerator DropTheFloorManager() {
		yield return new WaitForSeconds (2);
		int dropIndex2 = Random.Range (0, maxBlocks);
		int dropIndex = 0;
		while (true) {
			if(Random.Range(0,2) == 1){
				dropIndex = dropIndex2;
			}
			while(dropIndex == dropIndex2){
				dropIndex2 = Random.Range(0,maxBlocks);
			}
			PlayRandomSound(clips[dropIndex], 1f);
			yield return new WaitForSeconds (0.5f);
			sound.PlayOneShot(countDown,0.2f);
			yield return new WaitForSeconds (3);
			PlayRandomSound(clips[dropIndex], 1f);
			yield return new WaitForSeconds (3);
			dropAllButThis(dropIndex);
			sound.PlayOneShot(floorsDown,0.1f);
			yield return new WaitForSeconds (3);
			sound.PlayOneShot(floorsUp, 0.1f);
			StartCoroutine(liftBlocksAtIndex(dropIndex2));
			yield return new WaitForSeconds (3);
			yield return new WaitForSeconds (0.5f);
		}
	}
}

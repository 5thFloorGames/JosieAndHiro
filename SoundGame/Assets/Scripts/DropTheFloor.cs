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
		int dropIndex = 0;
		int dropIndex2 = 0;
		while (dropIndex == dropIndex2) {
			dropIndex2 = Random.Range (0, maxBlocks);
		}
		liftAllButThis(dropIndex);
		sound.PlayOneShot(floorsUp, 0.2f);
		yield return new WaitForSeconds (3);
		while (true) {
			int random = dropIndex;
			while (random == dropIndex) {
				random = Random.Range (0, maxBlocks);
			}
			dropIndex2 = random;
			PlayRandomSound(clips[dropIndex2], 1f);
			yield return new WaitForSeconds (0.5f);
			sound.PlayOneShot(countDown,0.2f);
			yield return new WaitForSeconds (4);
			PlayRandomSound(clips[dropIndex2], 1f);
			yield return new WaitForSeconds (4);
			StartCoroutine(dropBlocksAtIndex(dropIndex2));
			sound.PlayOneShot(floorsDown,0.2f);
			yield return new WaitForSeconds (3);
			if(Random.Range(0,2) == 0){
				int temp = dropIndex2;
				dropIndex2 = dropIndex;
				dropIndex = temp;
			}
			liftAllButThis(dropIndex);
			sound.PlayOneShot(floorsUp, 0.2f);
			yield return new WaitForSeconds (3);
			yield return new WaitForSeconds (0.5f);
		}
	}


}

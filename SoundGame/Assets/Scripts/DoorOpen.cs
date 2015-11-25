using UnityEngine;
using System.Collections;

public class DoorOpen: MonoBehaviour {

	private bool opening = false;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			Vector3 target = new Vector3 (transform.position.x, -2f, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, target, 1f * Time.deltaTime);
			if(transform.position == target){
				opening = false;
			}
		}
	}

	public void Open(){
		StartCoroutine ("WaitAndOpen");
	}

	IEnumerator WaitAndOpen(){
		yield return new WaitForSeconds (0.2f);
		opening = true;
		sound.PlayOneShot (sound.clip);
	}
}

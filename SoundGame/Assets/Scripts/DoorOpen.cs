using UnityEngine;
using System.Collections;

public class DoorOpen: MonoBehaviour {

	private bool opening = false;
	private bool closing = false;
	private bool open = false;
	private bool stuck = false;
	private AudioSource sound;
	public DoorOpen doorFriend;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			Vector3 target = new Vector3 (transform.position.x, -0.1f, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, target, 1f * Time.deltaTime);
			if(transform.position == target){
				opening = false;
				open = true;
				if(doorFriend != null){
					if(doorFriend.open){
						StuckOpen();
						doorFriend.StuckOpen();
					}
				}
			}
		}

		if (closing && !opening) {
			Vector3 target = new Vector3 (transform.position.x, 1f, transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, target, 1f * Time.deltaTime);
			if(transform.position == target){
				closing = false;
			}
		}
	}

	public void Open(){
		if (!stuck) {
			opening = true;
			sound.PlayOneShot (sound.clip);	
		}
	}

	public void StuckOpen(){
		stuck = true;
	}

	public void Close(){
		if (!stuck) {
			open = false;
			closing = true;
			sound.PlayOneShot (sound.clip);	
		}
	}	
}
